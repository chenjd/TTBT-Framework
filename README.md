
# TTBT-Framework


##What's TingTing Behaviour Trees?
----------

**TTBT-Framework** is a C# framework for building and running behaviour trees.It provides structures and algorithms that assist you in the task of creating intelligent agents for your game or application. 
The defination of behavior trees is based on the paper([Towards a Unified Behavior Trees Framework for Robot Control][1]).


##The Structure of TTBT-Framework


----------


TTBT-Framework has the following structure:

    .
    ├── .gitignore                    
    ├── README.md
    ├── Src                        // sources 
    │   ├── Base                   // base    
    │   |   ├── Blackboard.cs
    │   |   ├── NodeState.cs
    │   |   ├── Tick.cs
    │   |   └── Utilities.cs
    │   ├── Node                  //node defination
    │   |   ├── BaseNode.cs       //base class for all nodes
    │   |   ├── Composite         //composite node
    |   │   |   ├── _Composite.cs    //base class for composite nodes
    |   │   |   ├── Priority.cs
    |   │   |   └── Sequence.cs
    │   |   ├── Decorator         //decorator node
    |   │   |   ├── _Decorator.cs   //base class for decorator nodes
    |   │   |   └── Inverter.cs   //an example of decorator
    │   |   └── Leaf
    |   |       ├── _Leaf.cs
    |   |       ├── Action.cs   //base class for action nodes
    |   |       └── Condition.cs    //base class for condition nodes
    |   └── Tree
    │       └── BehaviorTree.cs
    └── Test                    //test folder        
        └── TTBTTest.cs 


**NOTE:   The test depends on Unity3D.**

##How to use TTBT-Framework


----------


TTBT-Framework supplys several composite, decorator and leaf nodes. You still can define your own nodes.It's simple.

1. Create action or condition nodes, inheriting from Action or Condition.
2. Create a behavior tree and set the root node to the tree.
3. Create a blackboard.

There is a sample on Unity3D.


        //structure of the tree
        
                          Priority(root)
                           /            \
                          /              \
                         /                \
                  Sequence1                Sequenc2
                  /    |   \                /     \
                 /     |    \              /       \
                /      |     \            /         \
           Condition1 Action1 Action2 Action3      Action4
      
      


----------


      //sample code 
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


----------


 
       
![此处输入图片的描述][2]   
       
  [1]: http://www.csc.kth.se/~miccol/Michele_Colledanchise/Publications_files/2013_ICRA_mcko.pdf
  [2]: http://images.cnblogs.com/cnblogs_com/murongxiaopifu/660764/o_TTBTTest.gif