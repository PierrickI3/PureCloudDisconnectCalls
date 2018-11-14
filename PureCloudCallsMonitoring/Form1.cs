using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PureCloudCallsMonitoring
{
	public partial class Form1 : Form
	{
		#region Global Vars

		TokensApi tokensApi = null;
		RoutingApi routingApi = null;
		AnalyticsApi analyticsApi = null;
		ConversationsApi conversationsApi = null;

		QueueInfo currentQueue = null;

		List<string> selectedConversationIds = new List<string>();
		List<AnalyticsConversation> conversationsToDisconnect = new List<AnalyticsConversation>();

		bool loggedIn = false;
		Timer timer = new Timer();

		#endregion

		#region Init

		public Form1()
		{
			InitializeComponent();

			AddLog("Initializing...");

			cmbEnvironment.SelectedIndex = 0;
			btnConnect.Select();

			Application.ApplicationExit += (sender, e) =>
			{
				Disconnect();
			};

			AddLog("Ready. Please enter your Client Id and Client Secret then click on Login.");
		}

		#endregion

		#region PureCloud Connection

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtClientId.Text) || string.IsNullOrEmpty(txtClientSecret.Text))
				{
					MessageBox.Show("Enter a client id & secret first.");
					return;
				}

				// Connect to PureCloud
				AddLog("Connecting...");
				Configuration.Default.ApiClient.RestClient.BaseUrl = new Uri($"https://api.{cmbEnvironment.SelectedItem.ToString()}");
				var accessTokenInfo = Configuration.Default.ApiClient.PostToken(txtClientId.Text, txtClientSecret.Text);
				Configuration.Default.AccessToken = accessTokenInfo.AccessToken;
				loggedIn = true;
				AddLog("Connected!");
				AddLog($"Access Token: {accessTokenInfo.AccessToken}", true);

				// Get APIs
				AddLog("Initializing APIs...", true);
				tokensApi = new TokensApi();
				routingApi = new RoutingApi();
				analyticsApi = new AnalyticsApi();
				conversationsApi = new ConversationsApi();
				AddLog("Finished initializing APIs...", true);

				// Update Controls
				btnConnect.Enabled = false;
				btnDisconnect.Enabled = true;
				gbQueues.Enabled = true;

				// Populate Queues
				GetQueues();
			}
			catch (Exception ex)
			{
				AddLog($"Error in btnConnect_Click: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConnect.Enabled = true;
				btnDisconnect.Enabled = false;
				gbQueues.Enabled = false;
				loggedIn = false;
			}
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			Disconnect();
		}

		private void Disconnect()
		{
			if (!btnDisconnect.Enabled) { return; }
			loggedIn = false;
			AddLog("Disconnecting...");
			tokensApi.DeleteTokensMe();
			btnConnect.Enabled = true;
			btnDisconnect.Enabled = false;
			gbQueues.Enabled = false;
			AddLog("Disconnected");
		}

		#endregion

		#region Queues

		private void GetQueues()
		{
			try
			{
				AddLog("Clearing current queues...", true);
				cmbQueues.Items.Clear();

				var pageNumber = 1;
				var pageCount = 1;

				do
				{
					var queueEntityListing = routingApi.GetRoutingQueues(100, pageNumber++, null, null, true);
					foreach (var queue in queueEntityListing.Entities)
					{
						cmbQueues.Items.Add(new QueueInfo(queue.Id, queue.Name));
					}
				} while (pageNumber <= pageCount && loggedIn);
				cmbQueues.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				AddLog($"Error in GetQueues: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void cmbQueues_SelectedIndexChanged(object sender, EventArgs e)
		{
			tvConversations.Nodes.Clear();

			currentQueue = (QueueInfo)((ComboBox)sender).SelectedItem;
			AddLog($"Selected Queue: {currentQueue.Id}, {currentQueue.Name}", true);

			// Get calls from the selected queue
			var conversations = GetCalls(currentQueue);
			AddLog($"Found {conversations.Count} active calls in {currentQueue.Name}");
			foreach (var conversation in conversations)
			{
				var newNode = tvConversations.Nodes.Add($"{conversation.ConversationId} => {DateTime.Now - conversation.ConversationStart}");
				newNode.Tag = conversation.ConversationId;
			}
		}

		#endregion

		#region Calls

		private List<AnalyticsConversation> GetCalls(QueueInfo queue)
		{
			AddLog($"Getting calls from queue {queue.Name}");
			var conversations = new List<AnalyticsConversation>();
			var pageNumber = 1;
			AnalyticsConversationQueryResponse analyticsConversationQueryResponse = null;

			var dateTimeNowISO = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
			var dateTimeNowISOMinus1Day = DateTime.UtcNow.AddDays(-7).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");

			AddLog($"Start Date/Time: {dateTimeNowISOMinus1Day}", true);
			AddLog($"End Date/Time: {dateTimeNowISO}", true);

			do
			{
				var body = new ConversationQuery()
				{
					Interval = $"{dateTimeNowISOMinus1Day}/{dateTimeNowISO}",
					ConversationFilters = new List<AnalyticsQueryFilter>()
				{
					new AnalyticsQueryFilter(
						AnalyticsQueryFilter.TypeEnum.And,
						new List<AnalyticsQueryClause>()
						{
							new AnalyticsQueryClause()
							{
								// Should not be disconnected
								Type = AnalyticsQueryClause.TypeEnum.And,
								Predicates = new List<AnalyticsQueryPredicate>()
								{
									new AnalyticsQueryPredicate()
									{
									   Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
									   Dimension = AnalyticsQueryPredicate.DimensionEnum.Conversationend,
									   _Operator = AnalyticsQueryPredicate.OperatorEnum.Notexists
									}
								}
							}
						}
					)
				},
					SegmentFilters = new List<AnalyticsQueryFilter>()
				{
					new AnalyticsQueryFilter(
						AnalyticsQueryFilter.TypeEnum.And,
						new List<AnalyticsQueryClause>()
						{
							new AnalyticsQueryClause()
							{
								Type = AnalyticsQueryClause.TypeEnum.And,
								Predicates = new List<AnalyticsQueryPredicate>()
								{
									// Should be a call
									new AnalyticsQueryPredicate()
									{
										Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
										Dimension = AnalyticsQueryPredicate.DimensionEnum.Mediatype,
										_Operator = AnalyticsQueryPredicate.OperatorEnum.Matches,
										Value = "voice"
									},
									// Should match selected queue
									new AnalyticsQueryPredicate()
									{
										Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
										Dimension = AnalyticsQueryPredicate.DimensionEnum.Queueid,
										_Operator = AnalyticsQueryPredicate.OperatorEnum.Matches,
										Value = queue.Id
									},
									// Should not be finished
									new AnalyticsQueryPredicate()
									{
										Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
										Dimension = AnalyticsQueryPredicate.DimensionEnum.Segmentend,
										_Operator = AnalyticsQueryPredicate.OperatorEnum.Notexists
									}

								}
							}
						}
					)
				},
					Order = ConversationQuery.OrderEnum.Asc,
					OrderBy = ConversationQuery.OrderByEnum.Conversationstart,
					Paging = new PagingSpec()
					{
						PageSize = 100,
						PageNumber = pageNumber++
					}
				};

				analyticsConversationQueryResponse = analyticsApi.PostAnalyticsConversationsDetailsQuery(body);
				AddLog($"Got response: {analyticsConversationQueryResponse.ToString()}", true);

				if (analyticsConversationQueryResponse.Conversations != null)
				{
					AddLog($"Got {analyticsConversationQueryResponse.Conversations.Count} conversations", true);
					foreach (var analyticsConversation in analyticsConversationQueryResponse.Conversations)
					{
						conversations.Add(analyticsConversation);
					}
				}

			} while (analyticsConversationQueryResponse.Conversations != null);

			return conversations;
		}

		private async void DisconnectConversation(string conversationId)
		{
			try
			{
				AddLog($"Disconnecting {conversationId}...");
				var result = await conversationsApi.PostConversationDisconnectAsync(conversationId);
				AddLog($"Conversation {conversationId} disconnected: {result}");
			}
			catch (Exception ex)
			{
				AddLog($"Error while disconnecting {conversationId}: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
			}
		}

		private void tvConversations_AfterCheck(object sender, TreeViewEventArgs e)
		{
			GetCheckedNodes(tvConversations.Nodes);
			AddLog($"{selectedConversationIds.Count} conversations selected");
			btnDisconnectSelectedConversations.Enabled = selectedConversationIds.Count > 0;
		}

		private void GetCheckedNodes(TreeNodeCollection nodes)
		{
			selectedConversationIds.Clear();
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
				{
					Console.WriteLine(node.Tag);
					selectedConversationIds.Add(node.Tag.ToString());
				}
				if (node.Nodes.Count > 0)
				{
					GetCheckedNodes(node.Nodes);
				}
			}
		}

		private void btnDisconnectSelectedConversations_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are you sure you want to disconnect the selected conversations? This cannot be undone!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				foreach (var selectedConversationId in selectedConversationIds)
				{
					DisconnectConversation(selectedConversationId);
				}
				GetCalls(currentQueue);
			}
		}
		
		#endregion

		#region Log

		private void AddLog(string message, bool verbose = false)
		{
			if (verbose && !chkVerboseLogging.Checked) { return; }
			lstLog.Items.Add($"{DateTime.Now} {message}");

			// Scroll
			int visibleItems = lstLog.ClientSize.Height / lstLog.ItemHeight;
			lstLog.TopIndex = Math.Max(lstLog.Items.Count - visibleItems + 1, 0);
		}

		private void btnClearLog_Click(object sender, EventArgs e)
		{
			lstLog.Items.Clear();
		}

		private void btnSaveLog_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Title = "Save Log File";
				saveFileDialog.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
				saveFileDialog.FilterIndex = 2;
				saveFileDialog.RestoreDirectory = true;

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					var streamWriter = new StreamWriter(saveFileDialog.FileName);
					foreach (var item in lstLog.Items)
					{
						streamWriter.WriteLine(item.ToString());
					}
					streamWriter.Close();
					AddLog($"Logs saved in {saveFileDialog.FileName}");
				}
			}
		}

		#endregion
	}
}
