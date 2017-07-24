//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace JMControlsEx
{
	public class JMTreeGridNodeEventBase
	{
        private JMTreeGridNode _node;

        public JMTreeGridNodeEventBase(JMTreeGridNode node)
		{
			this._node = node;
		}

        public JMTreeGridNode Node
		{
			get { return _node; }
		}
	}
	public class CollapsingEventArgs : System.ComponentModel.CancelEventArgs
	{
        private JMTreeGridNode _node;

		private CollapsingEventArgs() { }
        public CollapsingEventArgs(JMTreeGridNode node)
			: base()
		{
			this._node = node;
		}
        public JMTreeGridNode Node
		{
			get { return _node; }
		}

	}
    public class CollapsedEventArgs : JMTreeGridNodeEventBase
	{
        public CollapsedEventArgs(JMTreeGridNode node)
			: base(node)
		{
		}
	}

	public class ExpandingEventArgs:System.ComponentModel.CancelEventArgs
	{
        private JMTreeGridNode _node;

		private ExpandingEventArgs() { }
        public ExpandingEventArgs(JMTreeGridNode node)
            : base()
		{
			this._node = node;
		}
        public JMTreeGridNode Node
		{
			get { return _node; }
		}

	}
    public class ExpandedEventArgs : JMTreeGridNodeEventBase
	{
        public ExpandedEventArgs(JMTreeGridNode node)
            : base(node)
		{
		}
	}

	public delegate void ExpandingEventHandler(object sender, ExpandingEventArgs e);
	public delegate void ExpandedEventHandler(object sender, ExpandedEventArgs e);

	public delegate void CollapsingEventHandler(object sender, CollapsingEventArgs e);
	public delegate void CollapsedEventHandler(object sender, CollapsedEventArgs e);

}
