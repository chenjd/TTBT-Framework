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
	public abstract class BaseNode
	{
		#region Private Fields

		private Guid _id;
		private List<BaseNode> _children;

		#endregion

		#region public Constructor

        public BaseNode() : this(new List<BaseNode>())
        {
        }

		public BaseNode(List<BaseNode> children)
		{
			this._id = Utilities.CreateUUID();
			this._children = children != null ? children : new List<BaseNode>();
		}

		#endregion

		#region Public Methods
        
        //Enter Node -----> Open Node(maybe Running) -----> Tick Node(excute the logic) -----> Close Node(if not Running) -----> Exit Node
        public virtual NodeState Excute(Tick tick)
        {
          //Enter Node
          this.Enter(tick);

          //Open Node If current Node isnt in blackboard storage
          if(tick.Blackboard.GetNode(tick.Tree.UID, this._id) == null)
              this.Open(tick);

          //Tick Node, get the status
          NodeState status = this.Tick(tick);

          //Close Node, if not running depends on status
          if( status != NodeState.RUNNING )
            this.Close(tick);

          //Exit Node
          this.Exit(tick);

          //return result
          return status;
        }

        #endregion

        #region Private Methods

        private void Enter(Tick tick)
        { 
            //TODO
          if(tick == null)
            return;
          tick.EnterNode(this);
        }

        private void Open(Tick tick)
        {
            //TODO
          if(tick == null)
            return;
          tick.OpenNode(this);
        }

        protected virtual NodeState Tick(Tick tick)
        {
          //TODO
          return NodeState.SUCCESS;
        }

        private void Exit(Tick tick)
        {
          if(tick == null)
            return;
          tick.ExitNode(this);
        }

        private void Close(Tick tick)
        {
          if(tick == null)
            return;
          tick.CloseNode(this);
        }

		#endregion

        #region Public Properties

        public List<BaseNode> Children
        {
          get
          {
            return this._children;
          }
        }

        public Guid UID
        {
          get
          {
            return this._id;
          }
        }

        #endregion
	}
}