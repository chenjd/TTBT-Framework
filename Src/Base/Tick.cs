#region License
/*
 * The MIT License
 *
 * Copyright (c) 2015 Jiadong Chen(chenjd)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace TTBT
{
	public class Tick
	{
		#region Private Feilds

		private List<BaseNode> _openNodes;
		private int _nodeCount;
		private BehaviorTree _tree;
		private object _target;
		private Blackboard _blackboard;

		#endregion

		#region Public Constructors

		public Tick()
		{
			this._openNodes = new List<BaseNode>();
		}

		#endregion

		#region Public Methods

		public void EnterNode(BaseNode node)
		{
			this._nodeCount++;
			this._openNodes.Add(node);
		}

		public void OpenNode(BaseNode node)
		{
			//TODO
		}

		public void TickNode(BaseNode node)
		{
			//TODO
		}

		public void CloseNode(BaseNode node)
		{
			this._openNodes.Remove(node);
		}

		public void ExitNode(BaseNode node)
		{
		}

		#endregion

		#region Public Properties

		public List<BaseNode> OpenNodes
		{
			get
			{
				return this._openNodes;
			}
			set
			{
				this._openNodes = value;
			}
		}

		public BehaviorTree Tree
		{
			get
			{
				return this._tree;
			}

			set
			{
				this._tree = value;
			}
		}

		public object Target
		{
			get
			{
				return this._target;
			}

			set
			{
				this._target = value;
			}
		}

		public Blackboard Blackboard
		{
			get
			{
				return this._blackboard;
			}

			set
			{
				this._blackboard = value;
			}
		}

		#endregion
	}
}