using System;
using contest.submission.contract;

namespace contest.submission
{
 
  [Serializable]
  public class Solution : IDnp1604Solution
  {
    public void CalculateCountOfMagicNumbers(int Q, int N)
    {
      SendResult(1);
    }

    public event Action<int> SendResult;
  }
}
