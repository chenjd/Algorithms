// Author : 陈嘉栋
// Date   : 2015-05-20
// Blog   : http://www.cnblogs.com/murongxiaopifu/
///广度优先算法
///关键词：队列。
///步骤：以当前顶点为基准，将当前顶点一步就能到的（定义四个可能的方向，用for循环）、且没有走过的点入队。
///之后，当前顶点出队。以下一个顶点为基准，重复。直到队列为空
//顶点
using System;
class TestBFS
{
	static void Main(string[] args)
	{
		BFS bfs = new BFS();
		bfs.Excute(0, 0, 4, 3);
	}
}

class Node
{
	public int x;
	public int y;
	public int step;
	public Node(int x, int y, int step)
	{
		this.x = x;
		this.y = y;
		this.step = step;
	}
}

class BFS
{
	Node[] queue = new Node[100];
	int head;
	int tail;
	//地图，1为障碍，0为通路
	int[,] map = new int[5,4]{{0, 0, 1, 0}, {0, 0, 0, 0}, {0, 0, 1, 0}, {0, 1, 0, 0}, {0, 0, 0, 1}};
	//用来记录已经寻找过的路
	int[,] visited = new int[5, 4];
	//寻找当前顶点下一步能够走到的点
	int nextX;
	int nextY;
	//定义四个可以走的方向
	int[,] next = new int[4,2]{{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

	public void Excute(int startX, int startY, int targetX, int targetY)
	{
		//初始化，起点入队,并将起点加入到已经到达过的点
		Node node1 = new Node(startX, startY, 0);
		queue[0] = node1;
		tail++;
		this.visited[startX, startY] = 1;
		bool isFind = false;
		while(!isFind && head != tail)
		{
			//寻找当前顶点下一步可能到达的点。
			for(int i = 0; i < 4; i++)
			{
				//计算下一个点的位置
				nextX = queue[head].x + next[i, 0];
				nextY = queue[head].y + next[i, 1];
				//边界检测
				if(nextX >4 || nextX < 0 || nextY > 3 || nextY < 0)
					continue;
				//检测是否已经到过
				if(this.map[nextX, nextY] == 0 && this.visited[nextX, nextY] == 0)
				{
					//入队，队尾++
					queue[tail] = new Node(nextX, nextY, queue[head].step + 1);
					tail++;
					this.visited[nextX, nextY] = 1;
					if(nextX == targetX && nextY == targetY)
					{
						isFind = true;
					}
				}
			}
			//队头++，当前顶点的下一步可能到的点已经全部加入了队列，此时当前顶点出队。
			head++;
		}
		System.Console.WriteLine(queue[tail - 1].step);
	}
}
