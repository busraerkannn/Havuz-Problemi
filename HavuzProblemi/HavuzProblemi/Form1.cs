using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Graphviz;
using System.Threading;

namespace HavuzProblemi
{
    public partial class Form1 : Form
    {
        PaintEventArgs e;
        Label[] lDugum = new Label[20];
        Label[] lKapasite = new Label[50];
        Label[] lKapasite2 = new Label[50];
        int[,] graph = new int[20,20];
        int[,] graph2 = new int[20, 20];
        int[,] graph3 = new int[20, 20];
        int[] visited = new int[20];
        Stack<int> yigin = new Stack<int>();
        Stack<int> minKapasite= new Stack<int>();
        List<int> node = new List<int>();
        List<int> test = new List<int>();
        List<int> listMC = new List<int>();
        List<string> listKapasite= new List<string>();
        int nodeSayisi;
        public Form1()
        {
            
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            lblMaxFlow.Visible = false;

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
          
        }
        public int  minBulma(Stack<int> minKapasite)
        {
            int enKucuk = minKapasite.Peek();
            foreach(int n in minKapasite)
            {
                if(n<enKucuk)
                {
                    enKucuk = n;
                }
            }


            return enKucuk;
        }



        // Source:https://www.geeksforgeeks.org/minimum-cut-in-a-directed-graph/

        private bool bfs(int[,] GraphMC, int s,int t, int[] parent)
        {

            bool[] visited2 = new bool[GraphMC.Length];

            
            Queue<int> kuyruk = new Queue<int>();
            kuyruk.Enqueue(s);
            visited2[s] = true;
            parent[s] = -1;

            while (kuyruk.Count != 0)
            {
                int v = kuyruk.Dequeue();
                for (int i = 0; i < nodeSayisi; i++)
                {
                    if (GraphMC[v, i] > 0 && !visited2[i])
                    {
                        kuyruk.Enqueue(i);
                        visited2[i] = true;
                        parent[i] = v;
                    }
                }
            }

           
            return (visited2[nodeSayisi-1] == true);
        }

        private static void dfs2(int[,] GraphMC, int s, bool[] visited)
        {
            visited[s] = true;
            for (int i = 0; i < GraphMC.GetLength(0); i++)
            {
                if (GraphMC[s, i] > 0 && !visited[i])
                {
                    dfs2(GraphMC, i, visited);
                }
            }
        }

        public  void minCut(int[,] graph, int bas, int son)
        {
            int u, v;
            int[,] GraphMC = new int[graph.Length, graph.Length];
            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {
                    GraphMC[i, j] = graph[i, j];
                }
            }

             
            int[] parent = new int[graph.Length];

              
            while (bfs(GraphMC, bas, son, parent))
            {

               
                int akisYolu = int.MaxValue;
                for (v = son; v != bas; v = parent[v])
                {
                    u = parent[v];
                    akisYolu = Math.Min(akisYolu, GraphMC[u, v]);
                }

               
                for (v = son; v != bas; v = parent[v])
                {
                    u = parent[v];
                    GraphMC[u, v] = GraphMC[u, v] - akisYolu;
                    GraphMC[v, u] = GraphMC[v, u] + akisYolu;
                }
            }

          
            bool[] Visited2 = new bool[graph.Length];
            dfs2(GraphMC, bas, Visited2);

           
            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {
                    if (graph[i, j] > 0 && Visited2[i] && !Visited2[j])
                    {

                        listMC.Add(i);
                        listMC.Add(j);
                        Console.WriteLine(i + " - " + j);
                    }
                }
            }
            bool devam = true;
            int indexL = 0;
            int x1, y1, x2, y2;
            int okSayisi = listMC.Count / 2;
            int sayacOk = 0;
            while(indexL<listMC.Count && devam)
            {
                x1 = lDugum[listMC[indexL]].Location.X;
                y1= lDugum[listMC[indexL]].Location.Y;

                indexL = indexL + 1;
                x2 = lDugum[listMC[indexL]].Location.X;
                y2 = lDugum[listMC[indexL]].Location.Y;
                System.Drawing.Graphics grafiknesne;
                grafiknesne = this.CreateGraphics();
                Pen pen = new Pen(System.Drawing.Color.DarkOrchid, 2);
                
                grafiknesne.DrawLine(pen, x1, y1, x2, y2);
                sayacOk++;
                if(sayacOk==okSayisi)
                {
                    devam = false;
                }
                indexL++;
            }

        }



        public void dfs(int curNode)
        {
            
            bool kontrol = true;
            Console.WriteLine("Current:" + curNode);
            yigin.Push(curNode);
            visited[curNode] = 1;
            string s = lDugum[curNode].Name.ToString();
            int kapasite=0;
            for (int nextNode = 0; nextNode <nodeSayisi ; nextNode++)
            {
                string e = lDugum[nextNode].Name.ToString();
                string x = s + "-" + e;
                for(int i=0;lKapasite[i]!=null;i++)
                {
                    if(lKapasite[i].Name.Contains(x) )
                    {
                        string tmp = lKapasite[i].Text.ToString();
                        kapasite = Convert.ToInt32(tmp);
                        break;
                    }
                } 
                if (graph2[curNode,nextNode] == 1 && visited[nextNode] == 0 && graph[curNode,nextNode]>0)
                {
                    Console.WriteLine("Current:" + curNode+"NextNode:"+nextNode);
                    kontrol = false;

                    dfs(nextNode);
                    
                }
                else
                {
                    kontrol = true;
                }
            }
            if(kontrol)
            {
                int y = yigin.Peek();
                if (y != nodeSayisi-1)
                {
                    yigin.Pop();
                }
            }
    }

    private void button1_Click(object sender, EventArgs e)
        {
            this.AutoSize = true;
            System.Drawing.Graphics grafiknesne;
            grafiknesne = this.CreateGraphics();
            Pen pen = new Pen(System.Drawing.Color.Red, 2);
            List<Char> harf = new List<char>();
            List<Char> harf3 = new List<char>();
            for (char i ='A';i<'V';i++)
            {
                harf.Add(i);

            }
          


            int X = 400;
            int Y = 200;
            string v = txtMusluk.Text;
            nodeSayisi = Convert.ToInt16(v);
            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {
                    graph[i, j] = 0;
                    
                }
            }
            int tekX = 500;
            int tekY = 100;
            int ciftX = 500;
            int ciftY = 300;
            lDugum[0] = new Label();
            lDugum[0].Text =txtBaslangic.Text;
            lDugum[0].Location = new Point(X, Y);
            lDugum[0].BackColor = Color.White;
            lDugum[0].Width = 15;
            lDugum[0].Name = txtBaslangic.Text;
            string bas = txtBaslangic.Text;
            char tmp1 = Convert.ToChar(bas);
            harf.Remove(tmp1);
            string son = txtBitis.Text;
            char tmp2 = Convert.ToChar(son);
            harf.Remove(tmp2);
            this.Controls.Add(lDugum[0]);
            int t = 0;
            for (int i=1;i<nodeSayisi;i++)
            {
                lDugum[i] = new Label();
                lDugum[i].BackColor = Color.White;
                lDugum[i].Width = 15;
                
                if(i==nodeSayisi-1)
                {
                    lDugum[i].Text = txtBitis.Text;
                    lDugum[i].Name = txtBitis.Text;
                    lDugum[i].Location = new Point(X, Y);
                    this.Controls.Add(lDugum[i]);
                    break;
                }
                else if (i % 2 != 0)
                {
                    lDugum[i].Text = harf[t].ToString();
                    lDugum[i].Name = harf[t].ToString();
                    lDugum[i].Location = new Point(tekX, tekY);
                    tekX = tekX + 200;
                    X = X + 200;
                    
                }
                else
                {
                    lDugum[i].Text = harf[t].ToString();
                    lDugum[i].Name = harf[t].ToString();
                    lDugum[i].Location = new Point(ciftX, ciftY);
                    ciftX = ciftX + 200;
                }
               

                    this.Controls.Add(lDugum[i]);
                t++;    
            }
            string first,second;
            char[] d;
            List<Char> harf2 = new List<char>();
            List<string> kapasite = new List<string>();
            string s = richBaglanti.Text;
            string[] w = s.Split('\n');
            string s2 = richKapasite.Text;
            string[] w2 = s2.Split('\n');
            foreach(string k in w2)
            {
                kapasite.Add(k);
            }
            int x1=0,x2=0,y1=0,y2=0,index=0;
            foreach(string p in w)
            {
                foreach (char f in p)
                {

                    if(f!='-' && f!=' ')
                    {
                        harf2.Add(f);
                    }

                }
                first = harf2[0].ToString();
                second = harf2[1].ToString();
                for(int j=0;lDugum[j]!=null;j++)
                {
                    if(first.Equals(lDugum[j].Name))
                    {
                        x1 = lDugum[j].Location.X;
                        y1 = lDugum[j].Location.Y;

                    }
                    else if (second.Equals(lDugum[j].Name))
                    {
                        x2 = lDugum[j].Location.X;
                        y2 = lDugum[j].Location.Y;

                    }
                }
                int x3 = (x1 + x2) / 2;
                int y3 = (y1 + y2) / 2;
                lKapasite[index] = new Label();
                lKapasite[index].Text = kapasite[index].ToString();
                lKapasite[index].Location = new Point(x3, y3);
                lKapasite[index].BackColor = Color.Gray;
                lKapasite[index].Name = p;
                lKapasite[index].AutoSize = true;
                listKapasite.Add(kapasite[index]);
                this.Controls.Add(lKapasite[index]);
                //Thread.Sleep(1000);
                this.Refresh();
                Pen pen3 = new Pen(System.Drawing.Color.Red, 2);
                pen3.StartCap = LineCap.RoundAnchor;
                pen3.EndCap = LineCap.ArrowAnchor;
                grafiknesne.DrawLine(pen3, x1, y1, x2, y2);
                Thread.Sleep(2000);
                this.Refresh();
                Console.Read();
                harf2.Clear();
                index++;
            }
            
            
            
           
            string s3 = richBaglanti.Text;
            string[] w3 = s.Split('\n');
            foreach (string p in w3)
            {
                foreach (char f in p)
                {

                    if (f != '-' && f != ' ')
                    {
                        harf3.Add(f);
                    }

                }
            }
            int indexH = 0;
            index = 0;
            string str=null, str2;
            bool kontrol = true;
            bool devam = true;
            while (index<kapasite.Count() && kontrol)
            {
                str = harf3[indexH].ToString();
                for (int i = 0;lDugum[i]!=null; i++)
                {
                    if (str.Equals(lDugum[i].Name))
                    {
                        kontrol = true;
                        indexH = indexH + 1;
                        str2 = harf3[indexH].ToString();
                        for (int j = 0; lDugum[j] != null; j++)
                        {
                            if (str2.Equals(lDugum[j].Name))
                            {
                                int sayi= Convert.ToInt16(kapasite[index]);
                                graph3[i, j] = sayi;
                                graph[i,j] = sayi;
                                graph2[i, j] = 1;
                                graph2[j, i] = 1;
                                //graph[j, i] = sayi;
                                indexH++;
                                
                            }
                        }
                    }


                }
                if(indexH==harf3.Count()-1)
                {
                    kontrol = false;
                }
                index++;
            }

            for(int i=0;i<nodeSayisi;i++)
            {
                for(int j=0;j<nodeSayisi;j++)
                {
                    if(graph2[i,j]!=1)
                    {
                        graph2[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {
                    Console.Write(graph2[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {
                    
                     Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }


            int indexS = 0;
            int capacity = 0;
            bool z = true, c = true;
            int sayac = 0;
            int maxFlow = 0;
            
            while (z)
            {
                dfs(0);
                if (yigin.Count > 1)
                {
                    node = yigin.ToList();
                }
                else
                {
                    lblMaxFlow.Visible = true;
                    lblMaxFlow.Text = "Max Flow:" + maxFlow.ToString();
                    z = false;
                }
                while (indexS < node.Count && c && z)
                {
                    int a = node[indexS];
                    string st = lDugum[a].Name.ToString();
                    indexS++;
                    int b = node[indexS];
                    string st2 = lDugum[b].Name.ToString();
                    for (int i = 0; lKapasite[i] != null; i++)
                    {
                        if (lKapasite[i].Name.Contains(st) && lKapasite[i].Name.Contains(st2))
                        {
                            string tmp = lKapasite[i].Text.ToString();
                            capacity = Convert.ToInt32(tmp);
                            minKapasite.Push(capacity);
                            test.Add(i);
                           
                        }
                    }
                    if (indexS == node.Count - 1)
                    {
                        indexS = 0;
                        c = false;
                    }

                }
                test.Reverse();
                
                foreach(int k in minKapasite)
                {
                    Console.WriteLine("Min:" + k);
                }


                if (minKapasite.Count != 0)
                {
                    
                    int min = minBulma(minKapasite);
                    maxFlow = maxFlow + min;
                    foreach (int m in test)
                    {
                        
                        string st1 = lKapasite[m].Name;
                        char ch1 = st1[0];
                        string first2 = ch1.ToString();
                        char ch2 = st1[2];
                        string second2 = ch2.ToString();
                        for (int j = 0; lDugum[j] != null; j++)
                        {
                            if (first2.Equals(lDugum[j].Name))
                            {
                                x1 = lDugum[j].Location.X;
                                y1 = lDugum[j].Location.Y;

                            }
                            else if (second2.Equals(lDugum[j].Name))
                            {
                                x2 = lDugum[j].Location.X;
                                y2 = lDugum[j].Location.Y;

                            }
                        }
                        Pen pen2 = new Pen(System.Drawing.Color.Black, 2);
                        pen2.StartCap = LineCap.RoundAnchor;
                        pen2.EndCap = LineCap.ArrowAnchor;
                        grafiknesne.DrawLine(pen2, x1, y1, x2, y2);

                        Thread.Sleep(2000);
                        this.Refresh();
                        

                    }
                    
                   
                    
                    foreach (int m in test)
                    {
                        int eski = Convert.ToInt32(lKapasite[m].Text);
                        int yeni = eski - min;
                        lKapasite[m].Text = yeni.ToString();
                        string st1 = lKapasite[m].Name;
                        char ch1 = st1[0];
                        string first2 = ch1.ToString();
                        char ch2 = st1[2];
                        string second2 = ch2.ToString();
                        int n=0, k=0;
                        for (int j = 0; lDugum[j] != null; j++)
                        {
                            if (first2.Equals(lDugum[j].Name))
                            {
                                n = j;

                            }
                            else if (second2.Equals(lDugum[j].Name))
                            {
                                k = j;

                            }
                        }

                        graph[n, k] = yeni;
                        Console.WriteLine(graph[n, k] + "------");

                    }
                    Thread.Sleep(3000);
                    Pen pen6 = new Pen(System.Drawing.Color.Black, 2);
                    grafiknesne.DrawLine(pen6, 5000, 6000, 5400, 7000);
                    this.Refresh();
                    
                }

                if (sayac == 1)
                {
                    c = false;
                }
                minKapasite.Clear();
                yigin.Clear();
                test.Clear();
                for (int i = 0; i < nodeSayisi; i++)
                {
                    visited[i] = 0;
                }
                c = true;
                sayac++;
            }
            Thread.Sleep(1000);
            for (int i = 0; i < nodeSayisi; i++)
            {
                for (int j = 0; j < nodeSayisi; j++)
                {

                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; lKapasite[i] != null; i++)
            {
                lKapasite[i].Text = listKapasite[i];
            }
            minCut(graph3, 0, nodeSayisi-1);
            Console.Read();



           
        }

       
    }
}
