using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Graph
{
    public class Traversal
    {
        List<int>  bfs(List<List<int>> adj,ref List<bool>visited, ref List<int>storefBfs,int node)
        {
            visited[node] = true;
            storefBfs.Add(node);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int _node = queue.Dequeue();
                foreach(var e in adj[_node])
                {
                    if (!visited[_node])
                    {
                        visited[_node] = true;
                        queue.Enqueue(_node);
                    }
                }
            }
            return storefBfs;
        }
        
       public List<int> BfsOfGraph(List<List<int>>adj,int nodes)
        {
            List<int> storefBfs = new List<int>();
            List<bool> visited = new List<bool>();
            for(int i = 1; i <= nodes; i++)
            {
                visited.Add(false);
            }
            for(int i = 1; i <nodes; i++)
            {
                bfs(adj,ref visited,ref storefBfs,i);
            }
            return storefBfs;
        }

        List<int> dfsNonRecursive(List<List<int>> adj, ref List<bool> visited,int node,ref List<int> storeDfs)
        {
            Stack<int> stack =new Stack<int>();
            visited[node] = true;
            storeDfs.Add(node);
            stack.Push(node);
            while (stack.Count > 0)
            {
                int cur = stack.Peek();
                stack.Pop();
                foreach(var e in adj[node])
                {
                    if (!visited[e])
                    {
                        stack.Push(e);
                        visited[e] = true;
                        storeDfs.Add(e);
                    }
                }
            }
            return storeDfs;
        }
        void dfsRecursive(List<List<int>> adj, ref List<bool> visited, int node, ref List<int> storeDfs)
        {
            visited[node] = true;
            storeDfs.Add(node);
            foreach(var e in adj[node])
            {
                if (!visited[e])
                {
                    dfsNonRecursive(adj, ref visited, e, ref storeDfs);
                }
            }
        }
        public List<int> DFSOfGraph(List<List<int>>adj,int nodes)
        {
            
            List<int> storedDfs = new List<int>();
            List<bool> visited = new List<bool>(nodes);
            for(int i = 1; i <=nodes; i++)
            {
                visited.Add(false);
            }
            for (int i =1;i<nodes;i++)
            {
                if (!visited[i])
                {
                    dfsRecursive(adj, ref visited, i, ref storedDfs);
                }
            }
            return storedDfs;
        }
    }
}
