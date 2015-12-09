/*
The MIT License (MIT)
copyright © 2015 Jiadong Chen(chenjd)
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the “Software”), to deal in the Software without restriction, including without 
limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
the Software, and to permit persons to whom the Software is furnished to do so, subject to the following
conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions 
of the Software.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT 
SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.
*/

/*
                  Priority(root)
                   /            \
                  /              \
                 /                \
          Sequence1                Sequenc2
          /    |   \                /     \
         /     |    \              /       \
        /      |     \            /         \
   Condition1 Action1 Action2 Action3      Action4
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TTBT;

public class TTBTTest : MonoBehaviour {

    public GameObject agent;
    private BehaviorTree bt;
    private Blackboard bb;
	// Use this for initialization
	void Start () {
      List<BaseNode> children1 = new List<BaseNode>(){new Condition1(), new Action1(), new Action2()};
      List<BaseNode> children2 = new List<BaseNode>(){new Action3()};
      
      //create sequence node as root
      Sequence snode1 = new Sequence(children1);
      Sequence snode2 = new Sequence(children2);

      //create priority node as root
      Priority pnode = new Priority(new List<BaseNode>() { snode1, snode2});

      //create bt
      this.bt = new BehaviorTree(pnode);

      //create bb
      this.bb = new Blackboard();
	}
	
	// Update is called once per frame
	void Update () {
        this.bt.Tick(this.agent, this.bb);
	}
  
}

public class Condition1 : TTBT.Condition
{
  protected override NodeState Tick(Tick tick)
  {
    if(tick.Target != null && tick.Target is GameObject)
    {
      GameObject go = tick.Target as GameObject;
      if (Physics.Raycast(go.transform.position, go.transform.forward, 15f))
      {
        Debug.LogError("near wall");
        return NodeState.FAILURE;
      }
    }
    return NodeState.SUCCESS;
  }
}

public class Action1 : Action 
{
  protected override NodeState Tick(Tick tick)
  {
    if(tick.Target != null && tick.Target is GameObject)
    {
      ((GameObject)tick.Target).transform.Translate(0.1f * Vector3.forward);
    }
    return NodeState.SUCCESS;
  }
}

public class Action2 : Action 
{
  protected override NodeState Tick(Tick tick)
  {
    Debug.Log("moving");
    return NodeState.SUCCESS;
  }
}

public class Action3 : Action 
{
  protected override NodeState Tick(Tick tick)
  {
    if(tick.Target != null && tick.Target is GameObject)
    {
      ((GameObject)tick.Target).transform.Translate(100f * Vector3.back);
    }
    return NodeState.SUCCESS;
  }
}

public class Action4 : Action 
{
  protected override NodeState Tick(Tick tick)
  {
    Debug.Log("come back");
    return NodeState.SUCCESS;
  }
}