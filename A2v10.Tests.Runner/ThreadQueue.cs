// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A2v10.Tests.Runner
{

	public class ThreadQueue
	{
		ConcurrentQueue<Action> _queue = new ConcurrentQueue<Action>();

		public ThreadQueue()
		{
			Task.Run(() => DoRun());
		}

		public void Enqueue(Action action)
		{
			_queue.Enqueue(action);
		}

		public Boolean IsEmpty => _queue.Count == 0;

		private void DoRun()
		{
			while (true)
			{
				Thread.Sleep(50);
				if (_queue.TryDequeue(out Action action))
				{
					action();
				}
			}
		}
	}
}
