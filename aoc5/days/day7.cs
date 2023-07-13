using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{
    public class directory
    {
        public int size { get; set; }
        public string path { get; set; }
    }

    [Comment("Day 7: No Space Left On Device")]
    public class day7 : aocEvent
    {
        public day7(IInputFileService inputFileService) : base("day7", inputFileService)
        {
            files = new Dictionary<string, directory>();

            currentDir = new directory();
            foreach (string line in standardInput)
            {
                var allArgs = line.Split(" ");
                if (line.StartsWith("$ cd"))
                {
                    switch (allArgs[2])
                    {
                        case "/":
                            currentDir.path = "/root";
                            break;
                        case "..":
                            var pathSplit = currentDir.path.Split("/").ToList();
                            pathSplit.Pop();  //remove the last dir and / since .. means go back one directory
                            currentDir.path = string.Join("/", pathSplit); //convert the list to string and set the path
                            break;
                        default:
                            currentDir.path += "/" + allArgs[2];
                            break;
                    }
                    int oldSize = 0;
                    if (files.ContainsKey(currentDir.path))
                    {
                        oldSize = files[currentDir.path].size;
                    }
                    files[currentDir.path] = new directory
                    {
                        path = currentDir.path,
                        size = oldSize,
                    };
                }
                else if (char.IsDigit(line[0]))
                {
                    int oldSize = 0;
                    if (files.ContainsKey(currentDir.path))
                    {
                        oldSize = files[currentDir.path].size;
                    }
                    int newZize = oldSize + int.Parse(allArgs[0]);
                    files[currentDir.path] = new directory
                    {
                        path = currentDir.path,
                        size = newZize,
                    };
                    currentDir.size = newZize;
                }
            }
            files["/root"].size = 0;

        }
        public directory currentDir { get; set; }
        public Dictionary<string, directory> files { get; set; }

        public int sizeBelow100k()
        {
            int i = 0;
            foreach (directory dir in files.Values)
            {
                if (dir.size < 100000)
                {
                    i += dir.size;
                }
            }
            return i;
        }

    }
}
