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
    //save base info
    public struct BaseMemory
    {
      public Dictionary<Guid, TreeMemory> baseMemory;

      public BaseMemory(Dictionary<Guid, TreeMemory> dic)
      {
        this.baseMemory = dic;
      }
    }

    //save tree-nodes ref
    public struct TreeMemory
    {
      public Dictionary<Guid, BaseNode> treeMemory;
      public List<BaseNode> openNodes;

      public TreeMemory(Dictionary<Guid, BaseNode> dic, List<BaseNode> nodes)
      {
          this.treeMemory = dic;
          this.openNodes = nodes;
      }
    }

    //Blackboard class
	public class Blackboard{

		#region Private Fields

		private BaseMemory _baseMemory;
		private TreeMemory _treeMemory;

		#endregion
	
		#region Constructor

		public Blackboard()
		{
			this._baseMemory = new BaseMemory(new Dictionary<Guid, TTBT.TreeMemory>());
			this._treeMemory = new TreeMemory(new Dictionary<Guid, BaseNode>(), new List<BaseNode>());
		}

		#endregion

        #region Public Methods

        //get
        public TreeMemory GetTree(Guid treeID)
        {
          if(!this._baseMemory.baseMemory.ContainsKey(treeID))
          {
            this._baseMemory.baseMemory.Add(treeID, new TTBT.TreeMemory(new Dictionary<Guid, BaseNode>(), new List<BaseNode>()));
          }
          return this._baseMemory.baseMemory[treeID];
        }

        public BaseNode GetNode(Guid treeID, Guid nodeID)
        {
          TreeMemory tree = this.GetTree(treeID);
          if(!tree.treeMemory.ContainsKey(nodeID))
          {
            tree.treeMemory.Add(nodeID, null);
          }
          return tree.treeMemory[nodeID];
        }

        public List<BaseNode> GetOpenNodes(Guid treeID)
        {
          TreeMemory tree = this.GetTree(treeID);
          return tree.openNodes;
        }

        //set
        public void SetOpenNodes(Guid treeID, List<BaseNode> nodes)
        {
          TreeMemory tree = this.GetTree(treeID);
          tree.openNodes = nodes;
        }

        #endregion

		#region Public Properties

		public BaseMemory BaseMemory
		{
			get
			{
				return this._baseMemory;
			}
		}


		public TreeMemory TreeMemory
		{
			get
			{
				return this._treeMemory;
			}
		}

		#endregion

	}
}