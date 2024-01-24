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
		public void AddAtIndex(T item, uint index)
		{
			CheckIntegrity();
			//Swap current item with next item, repeat until we reach _count
			_count++;
			T currentItem = item;
			T nextItem;
			for (int i = (int)index; i < _items.Length; i++)
			{
				nextItem = _items[i];
				_items[i] = currentItem;
				currentItem = nextItem;
			}
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

