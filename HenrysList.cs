using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
	public class HenrysList<T> : IEnumerable<T>
	{
		private T[] _items;
		private T[] _interItems = new T[1];
		private int _count;
		private const int InitialCapacity = 100;

		public HenrysList()
		{
			_items = new T[InitialCapacity];
			_count = 0;
		}

		public HenrysList(uint capacity)
		{
			
			_items = new T[capacity];
			_count = 0;
		}

		public void Add(T item)
		{
			CheckIntegrity();
			_items[_count] = item;
			_count++;
		}
		public void AddAtIndex(T item, int index)
		{
			CheckIntegrity();
			//Swap current item with next item, repeat until we reach _count
			_count++;
			T currentItem = item;
			T nextItem;
			for (int i = index; i < _items.Length; i++)
			{
				nextItem = _items[i];
				_items[i] = currentItem;
				currentItem = nextItem;
			}
		}
		/// <summary>
		/// Removes the item at a given index and then removes the gap in the list and shortens it. notAnIndex is an index.
		/// </summary>
		/// <param name="notAnIndex"></param>
		public void RemoveAtIndex(int notAnIndex)
		{
			//Something here causes an error. Debugging is impossible. Break points don't work. Exceptions give no useful information.
			//And I can't find a flaw with the logic here. Time to start over.

			T currentItem = _items[_items.Length - 1];
			T nextItem;
			for (int i = _count - 1; i > notAnIndex; i--)
			{
				//if (i - 1 < 0)
				//{
				//	throw new Exception("Out of range, too small!");
				//}
				nextItem = _items[i - 1];
				_items[i - 1] = currentItem;
				currentItem = nextItem;
			}
			_count--;

			//IT THROWS AN ERROR WITH NO CODE IN IT. THIS IS IMPOSSIBLE. I GIVE UP!
			//Turns out that using the variable name "index" throws an out of bounds exception. But only in this method. Why?!?!
			//That's enough C# and enough Windows for today.
			
		}

		public void CheckIntegrity()
		{
			if (_count > _items.Length * 0.8)
			{
				_interItems = _items;
				_items = new T[_count * 2];
				for (int i = 0; i < _interItems.Count(); i++)
				{
					_items[i] = _interItems[i];
				}
				_interItems = new T[1];
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _count; i++)
			{
				yield return _items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

