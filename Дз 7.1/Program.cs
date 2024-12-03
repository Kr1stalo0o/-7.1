
char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
char currentPlayer = 'X';
int moves = 0;

while (true)
{
    Console.Clear();

    Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
    Console.WriteLine("---|---|---");
    Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
    Console.WriteLine("---|---|---");
    Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");

    Console.WriteLine($"Player {currentPlayer}, select a cell (1-9):");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
    {
        board[choice - 1] = currentPlayer;
        moves++;

        int[,] winCombinations = new int[,]
        {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, 
            { 0, 4, 8 }, { 2, 4, 6 }             
        };

        bool win = false;
        for (int i = 0; i < winCombinations.GetLength(0); i++)
        {
            if (board[winCombinations[i, 0]] == currentPlayer &&
                board[winCombinations[i, 1]] == currentPlayer &&
                board[winCombinations[i, 2]] == currentPlayer)
            {
                win = true;
                break;
            }
        }

        if (win)
        {
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine($"Player {currentPlayer} won!");
            break;
        }

        if (moves == 9)
        {
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine("Draw!");
            break;
        }

        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
    else
    {
        Console.WriteLine("Incorrect move. Try again");
    }
}