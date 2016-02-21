using System;

namespace contest.submission.contract
{
    public interface IDnp1604Solution
    {
      void CalculateCountOfMagicNumbers(int Q, int N);

      event Action<int> SendResult;
    }
}
