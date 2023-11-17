using System;
using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;

namespace ListForMivnei
{
    internal class Program
    {


        public static void PrintMyList(Node<int> head1)
        {
            // head >> 1 >> 2 >> 5 >> null
            // head >> 2 >> 5 >> null
            // head >> 5 >> null
            // head >> null

            while (head1 != null)
            {
                Console.Write(head1.GetValue() + ">>");
                head1 = head1.GetNext();
            }
            Console.WriteLine("null");
        }

        public static int SumValue(Node<int> head)
        {

            // head >> 1 >> 2 >> 5 >> null  sum =0
            // head >> 2 >> 5 >> null  sum = 1
            // head >> 5 >> null  sum = 3
            // head >> null  sum = 8


            int sum = 0;
            while (head != null)
            {
                sum += head.GetValue();
                head = head.GetNext();
            }
            return sum;
        }

        public static Node<int> GenerateRandomList(int length)
        {
            if (length <= 0)
            {
                return null; // Return null for an empty list or invalid length.
            }

            Random rand = new Random();
            Node<int> head = new Node<int>(rand.Next(-100, 101)); // Create the first node with a random number.

            Node<int> current = head;

            for (int i = 1; i < length; i++)
            {
                int randomValue = rand.Next(-100, 101);
                Node<int> newNode = new Node<int>(randomValue);
                current.SetNext(newNode);
                current = newNode;
            }

            return head;
        }

        public static void PrintList(Node<int> headOfList)
        {
            while (headOfList != null)
            {
                int num = headOfList.GetValue();
                Console.Write($"{num}>>");
                headOfList = headOfList.GetNext();

            }
            Console.WriteLine("null");
        }

        public static int MaxOfList(Node<int> headOfMyList)

        {

            if (headOfMyList == null)
            {
                return 0;
            }
            int max = headOfMyList.GetValue();
            headOfMyList = headOfMyList.GetNext();
            while (headOfMyList != null)
            {
                if (max < headOfMyList.GetValue())
                {
                    max = headOfMyList.GetValue();
                }
                headOfMyList = headOfMyList.GetNext();

            }
            return max;

        }

        public static int SumList(Node<int> headOfList)
        {
            int sum = 0;
            while (headOfList != null)
            {
                int value = headOfList.GetValue();
                sum += value;
                headOfList = headOfList.GetNext();

            }
            return sum;
        }

        public static int NumOfNodes(Node<int> headOfList)
        {
            int lengthOfList = 0;

            while (headOfList != null)
            {
                lengthOfList++;
                headOfList = headOfList.GetNext();

            }
            return lengthOfList;
        }

        public static int[] ListToArr(Node<int> headOfList)
        {
            int lengthOfList = NumOfNodes(headOfList);
            int[] arr = new int[lengthOfList];
            for (int i = 0; i < lengthOfList; i++)
            {
                arr[i] = headOfList.GetValue();
                headOfList = headOfList.GetNext();
            }
            return arr;
        }

        public static bool IsListEven(Node<int> headOfList)
        {
            int lengthOfList = NumOfNodes(headOfList);
            return lengthOfList % 2 == 0;
        }

        public static Node<int> ToAdd(Node<int> lst, int num)
        {
            if (lst == null)
            {
                return new Node<int>(num);
            }


            Node<int> nodeToAdd = new Node<int>(num);
            nodeToAdd.SetNext(lst);
            lst = nodeToAdd;
            return lst;


        }

        public static Node<int> AddFirst(Node<int> lst, int num)

        {
            // רשימה ריקה
            if (lst == null)
            {
                lst = new Node<int>(num);
            }
            // רשימה לא ריקה
            else
            {
                Node<int> NodeToAdd = new Node<int>(num);
                NodeToAdd.SetNext(lst);
                lst = NodeToAdd;
            }
            return lst;
        }
        public static Node<int> AddLast(Node<int> lst, int num)

        {
            Node<int> current = lst;
            // רשימה ריקה
            if (lst == null)
            {
                lst = new Node<int>(num);
            }
            // רשימה לא ריקה
            else
            {
                Node<int> NodeToAdd = new Node<int>(num);
                while (current.HasNext())
                {
                    current = current.GetNext();
                }
                current.SetNext(NodeToAdd);

            }
            return lst;
        }

        public static Node<int> AddNodeToNPlace(Node<int> lst, int valueToAdd, int nPlace)
        {
            if (lst == null)
            {
                return new Node<int>(valueToAdd);
            }

            int lengthOfList = NumOfNodes(lst);
            Console.WriteLine($"length is{lengthOfList} ");
            if (lengthOfList < nPlace)
            {
                AddLast(lst, valueToAdd);
            }
            Node<int> current = lst;
            Node<int> nodeToAdd = new Node<int>(valueToAdd);
            for (int i = 1; i < nPlace; i++)
            {
                current = current.GetNext();

            }
            nodeToAdd.SetNext(current.GetNext());
            current.SetNext(nodeToAdd);

            return lst;


        }


        public static bool IsPrefix(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return true;
            }
            if (lst2 == null)
            {
                return false;
            }

            while (lst1 != null)
            {
                if (lst2 == null || lst1.GetValue() != lst2.GetValue())
                {
                    return false;
                }

                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();
            }
            return true;
        }



        public static bool IsSubChain(Node<int> lst1, Node<int> lst2)
        {
            while (lst2 != null)
            {
                if (IsPrefix(lst1, lst2))
                {
                    return true;
                }
                lst2 = lst2.GetNext();
            }
            return false;

        }
        static Node<T> CreateLinkedList<T>(params T[] values)
        {
            Node<T> head = null;
            Node<T> current = null;

            for (int i = 0; i < values.Length; i++)
            {
                T value = values[i];

                if (head == null)
                {
                    head = new Node<T>(value);
                    current = head;
                }
                else
                {
                    Node<T> newNode = new Node<T>(value);
                    current.SetNext(newNode);
                    current = newNode;
                }
            }

            return head;
        }

        // פעולה המקבלת רשימה ומחזירה הפניה לעותק של הרשימה
        // פעולה זו מהווה את הבסיס לכל שאלות בניית רשימה

        public static Node<int> CopyList (Node<int> original)
        {
            Node<int> head = new Node<int>(-88) ;

            Node<int> current = head;
            while (original!=null)
            {
                Node<int> nodeToAdd = new Node<int>(original.GetValue());
                current.SetNext(nodeToAdd);
                current = current.GetNext();
                original = original.GetNext();

            }
            return head.GetNext();
        }
        // יש לכתוב פעולה המקבלת רשימה ומחזירה רשימה חדשה של הזוגיים בלבד
        public static Node<int> CreateEvenList(Node<int> original)
        {
            Node<int> head = new Node<int>(-88);
            Node<int> current = head;
            while (original != null)
            {

                if (original.GetValue()%2==0)
                {
                    Node<int> nodeToAdd = new Node<int>(original.GetValue());
                    current.SetNext(nodeToAdd);
                    current = current.GetNext();

                }
              
             
                original = original.GetNext();

            }
            return head.GetNext();
        }

    

        // יש לכתוב פעולה המקבלת הפניה לרשימה ומספר ומוסיפה חוליה בתחילת רשימה

        public static Node<int> AddFirstOnList (Node<int> original, int num)

        {

            Node<int> nodeToAdd = new Node<int>(num);
            nodeToAdd.SetNext(original);
            return nodeToAdd;
        }

        // יש לכתוב פעולה המוסיפה חוליה בסוף


        public static Node<int> AddLastOnList(Node<int> original, int num)
        {
            Node<int> nodeToAdd = new Node<int>(num);
            Node<int> current = original;

            while (current.HasNext())
            {
                current = current.GetNext();
            }
            current.SetNext(nodeToAdd);
            return original;
           



        }



        // יש לכתוב פעולה המקבלת מספר חיובי עד 20
        // אם המספר לא בטווח תוחזר רשימה ריקה
        //  הפעולה תחזיר רשימה הכוללת חוליות מ-1 עד המספר
        static void Main(string[] args)
        {
            Node<int> lst1OnMain = CreateLinkedList(1, 2,3,4);

            Node<int> newList= AddLastOnList(lst1OnMain,100);


            PrintList(newList);



        }
    }
}
