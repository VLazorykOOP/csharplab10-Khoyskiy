public class PositiveNegativeOrder
{
    public void ProcessFile(string filePath)
    {
        Queue<int> positiveQueue = new Queue<int>();
        Queue<int> negativeQueue = new Queue<int>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    int number = int.Parse(reader.ReadLine());

                    if (number > 0)
                    {
                        positiveQueue.Enqueue(number);
                    }
                    else if (number < 0)
                    {
                        negativeQueue.Enqueue(number);
                    }
                }
            }

            PrintQueue(positiveQueue);
            PrintQueue(negativeQueue);
        }
        catch (FileNotFoundException ex)
        {
            throw new PositiveNegativeOrderException($"File not found: {ex.Message}");
        }
        catch (FormatException ex)
        {
            throw new PositiveNegativeOrderException($"Invalid format: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            throw new PositiveNegativeOrderException($"Number is too large or too small: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new PositiveNegativeOrderException($"An error occurred while processing the file: {ex.Message}");
        }
    }

    private void PrintQueue(Queue<int> queue)
    {
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }

    public void Run()
    {
        string filePath = "input.txt";
        ProcessFile(filePath);
    }
}