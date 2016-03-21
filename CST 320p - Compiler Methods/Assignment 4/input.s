^l1	
			mov	%r0,	$0
			print	%r0
			jmp	{}, l2

^add_num
			sub	%r13,	$4
			mov	<%r13, $0, $4>,		<%r13, $8, $4>
			add <%r13, $0, $4>,		<%r13, $12, $4>

			mov	%r0,	<%r13, $0, $4>
			returnp	$4

^start		//entry point
	accept	%r0	// read a value into register r0
	accept	%r1	//	read a 32-bit value into register r1

	// get prepared to call function add_num
	push	%r0
	push	%r1
	call add_num
	add	%r13, $8	// adjust the stack so that it is ok 

// just for the kick of it, jump conditionally to l1
	accept	%r3
	jmp {eq, %r3, $5}, l1

	^l2
	printreg
