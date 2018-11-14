using System;

namespace PureCloudCallsMonitoring
{
	public class QueueInfo
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public QueueInfo(string id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
