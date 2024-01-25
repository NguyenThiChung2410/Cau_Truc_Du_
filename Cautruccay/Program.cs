using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cautruccay
{
    class Tnode
    {
        public int Info;
        public Tnode Left;
        public Tnode Right;

        public Tnode(int x)
        {
            Info = x;
            Left = null;
            Right = null;
        }
    }
    class BinaryTree
    {
        public Tnode Root;

        public BinaryTree()
        {
            Root = null;
        }
        public void NLR(Tnode root)
        {
            if (root != null)
            {
                Console.Write($"{root.Info}");
                NLR(root.Left);
                NLR(root.Right);
            }
        }
        public void LNR(Tnode root)
        {
            if (root != null)
            {
                LNR(root.Left);
                Console.Write($"{root.Info} ");
                LNR(root.Right);
            }
        }
        public void LRN(Tnode root)
        {
            if (root != null)
            {
                LRN(root.Left);
                LRN(root.Right);
                Console.Write($"{root.Info} ");
            }
        }
        public void ThemNode(ref Tnode root,int x)
        {
            if (root == null)
            {
                Tnode p = new Tnode(x);
                root = p;
            }
            else if (root.Info > x)
                ThemNode(ref root.Left, x);
            else if (root.Info < x)
                ThemNode(ref root.Right, x);
        }
        public void TaoCay()
        {
            Console.Write("Cho biet so nut trong cay:");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.Write("Nhap gia tri node thu ", +i + ":");
                int x = int.Parse(Console.ReadLine());
                ThemNode(ref Root, x);
            }
        }
        public Tnode TimKiem(Tnode root,int x)
        {
            Tnode kq = null;
            if (root != null)
            {
                if (root.Info == x)
                    kq = root;
                else if (x < root.Info)
                    kq = TimKiem(root.Left, x);
                else
                    kq = TimKiem(root.Right, x);
            }
            return kq;
        }
            
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.TaoCay();
            Console.WriteLine("Ket qua duyet cay:");

            Console.Write("\nNLR:");
            tree.LNR(tree.Root);

            Console.Write("\nLNR:");
            tree.LNR(tree.Root);

            Console.Write("\nLRN:");
            tree.LRN(tree.Root);

            Console.Write("\nNhap gia tri nut can tim:");
            int x = int.Parse(Console.ReadLine());
            Tnode kq = tree.TimKiem(tree.Root, x);
            if (kq == null)
                Console.WriteLine($"{x} khong xuat hien trong cay");
            else
                Console.WriteLine($"{x} co xuat hien trong cay");
            Console.ReadLine();
        }
    }
}
