
using System;

namespace A2v10.Tests.Browser
{
	public enum RunStatus
	{
		Unknown,
		Success,
		Failure
	}

	public class RunScenario : IRunScenario
	{
		private Exception _exception;
		private RunStatus _status;

		public String Name { get; set; }
		public String Description { get; set; }

		public Exception Exception => _exception;
		public Boolean IsSuccess => _status == RunStatus.Success;
		public Boolean IsFailure => _status == RunStatus.Failure;

		public RunScenario()
		{
			_status = RunStatus.Unknown;
		}

		public void SetSuccess()
		{
			_status = RunStatus.Success;
		}

		public void WriteException(Exception ex)
		{
			_status = RunStatus.Failure;
			_exception = ex;
		}
	}
}
