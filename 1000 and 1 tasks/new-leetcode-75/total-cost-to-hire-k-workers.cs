public class Solution {
    // costs = costs of hiring i-th worker 
    // k workers to hire. 1 per session
    // candidates - насколько от начала или конца мы можем ходить
    // индекс приоритет

    public long TotalCost(int[] costs, int k, int candidates) {
        var leftPq = new PriorityQueue<int, int>();
        for (int i = 0; i < candidates; i++) {
            leftPq.Enqueue(costs[i], costs[i]);
        }
        var lastLeftIndex = candidates - 1;

        var rightPq = new PriorityQueue<int, int>();
        var firstRightIndex = -1; 
        for (int i = 0, j = costs.Length - 1; i < candidates && j > lastLeftIndex; i++, j--) {
            rightPq.Enqueue(costs[j], costs[j]);
            firstRightIndex = j;
        }

        long result = 0;
        for (int i = 0; i < k; i++)
        {
            if (leftPq.Count > 0 && rightPq.Count > 0)
            {
                if (leftPq.Peek() <= rightPq.Peek())
                {
                    result += leftPq.Dequeue();
                    // добавить новый?
                    if (lastLeftIndex + 1 < firstRightIndex)
                    {
                        lastLeftIndex++;
                        leftPq.Enqueue(costs[lastLeftIndex], costs[lastLeftIndex]);
                    }
                }
                else
                {
                    result += rightPq.Dequeue();
                    if (firstRightIndex - 1 > lastLeftIndex)
                    {
                        firstRightIndex--;
                        rightPq.Enqueue(costs[firstRightIndex], costs[firstRightIndex]);
                    }
                }
            }
            else if (leftPq.Count > 0)
            {
                result += leftPq.Dequeue();
                // добавить новый?
                if (lastLeftIndex + 1 < firstRightIndex)
                {
                    lastLeftIndex++;
                    leftPq.Enqueue(costs[lastLeftIndex], costs[lastLeftIndex]);
                }
            }
            else
            {
                result += rightPq.Dequeue();
                if (firstRightIndex - 1 > lastLeftIndex)
                {
                    firstRightIndex--;
                    rightPq.Enqueue(costs[firstRightIndex], costs[firstRightIndex]);
                }
            }
        }

        return result;
    }
}