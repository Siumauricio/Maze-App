using MazeGeneratorApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MazeGeneratorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeGeneratorController : ControllerBase
    {

        [HttpGet("GenerateMaze/{n}/{m}")]
        public IActionResult generate(int n, int m)
        {
            MazeGenerator mazeGenerator = new MazeGenerator();

            bool finalized = false;

            while (!finalized)
            {
                try
                {
                    mazeGenerator.crearLaberinto(n+2, m+2);
                    finalized = true;
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                }
            }

            MazeList maze = new MazeList();
            maze.Size = n;
            Console.WriteLine("<><><>><><");
            for (int i = 1; i < mazeGenerator.nMax - 1; i++)
            {
                for (int j = 1; j < mazeGenerator.mMax - 1; j++)
                {
                    Console.Write(mazeGenerator.M[i, j]);
                    maze.Result.Add(new PositionValue(i-1, j-1, mazeGenerator.M[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine("<><><>><><");

            return this.Ok(maze);
        }
    }
}
