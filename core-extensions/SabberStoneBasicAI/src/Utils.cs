using System;
using System.Threading;
using System.Threading.Tasks;


namespace SabberStoneBasicAI
{
    public class ProgressMonitor
    {
        private long _currentProgress;
        private readonly long _totalItems;
        private readonly Action<long> _progressCallback;
		private readonly object _lock = new();
		private readonly ManualResetEventSlim _completionEvent = new(false);

        public ProgressMonitor(long totalItems, Action<long> progressCallback)
        {
            _totalItems = totalItems;
            _progressCallback = progressCallback;
            _currentProgress = 0;
        }

        public void Increment(long count = 1)
        {
            var newCount = Interlocked.Add(ref _currentProgress, count);
			lock (_lock)
			{
				_progressCallback(_currentProgress);
			}

			if (newCount >= _totalItems)
				_completionEvent.Set();
        }

		public void WaitForCompletion()
		{
			_completionEvent.Wait();
		}

		public void WaitForCompletion(TimeSpan timeout)
		{
			_completionEvent.Wait(timeout);
		}

        public long CurrentProgress => _currentProgress;
        public long TotalItems => _totalItems;
    }
}
