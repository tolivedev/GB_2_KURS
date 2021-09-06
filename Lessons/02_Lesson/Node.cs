using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._02_Lesson
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList<T>
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(Node<T> value);  // добавляет новый элемент списка
        void AddNodeAfter(Node<T> node, Node<T> value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node<T> node); // удаляет указанный элемент
        Node<T> FindNode(T searchValue); // ищет элемент по его значению
    }

}
