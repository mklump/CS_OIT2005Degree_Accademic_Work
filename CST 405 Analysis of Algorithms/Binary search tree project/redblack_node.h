#pragma once
#include "tree_node.h"

class redblack_node :
	public  tree_node
{
public:
	redblack_node(
				  void
				  );
	~redblack_node(
				   void
				   );
	void
	RB_Insert(
			  redblack_node *T,	// pointer to entire tree T
			  redblack_node *z	// node to insert into tree T
			  );
	void
	RB_Insert_Fixup(
					redblack_node *T,	// pointer to entire tree T
					redblack_node *z	// node to fixup the color of in tree T
					);
	redblack_node *
	RB_Delete(
			  redblack_node *T,		// pointer to entire tree T
			  redblack_node *z		// node to delete
			  );
	void
	RB_Delete_Fixup(
					redblack_node *T,	// pointer to entire tree T
					redblack_node *z	// node to fixup
					);
	void
	Left_Rotate(
				redblack_node *T,		// pointer to entire tree T
			    redblack_node *x		// node to rotate
			    );
	void
	Right_Rotate(
				redblack_node *T,		// pointer to entire tree T
			    redblack_node *x		// node to rotate
			    );
	redblack_node *
	get_Right(
			  void
			  )	   { return right; }
private:
	char *color;
	redblack_node *left;
	redblack_node *right;
	redblack_node *parent;
};
