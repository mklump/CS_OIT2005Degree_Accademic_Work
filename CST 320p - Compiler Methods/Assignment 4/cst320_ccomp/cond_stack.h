#ifndef _cond_stack_h
#define	_cond_stack_h

#ifdef	__cplusplus
extern	"C"
{
#endif

typedef	enum	_condition_t
{
	cond_if,
	cond_if_else,
	cond_while
} condition_t;

typedef	struct	condition_stack_item_t
{
	condition_t				cond_code;
	struct	_if_t {
		int	if_label;
	}	_if;

	struct	_if_else_t {
		int	out_if_else_label;
	}	if_else;

	struct	_while_t {
		int	while_label;

		int	out_while_label;
	} _while;

} condition_stack_item_t;

void
initialize_condition_stack();

void
push_condition_item(
					condition_stack_item_t	*pItem
					);

condition_stack_item_t	*
pop_condition_item(
				   condition_stack_item_t	*pItemToReturn
				   );

condition_stack_item_t	*
get_tos_condition_stack(
					condition_stack_item_t	*pItemToReturn
					);

#ifdef __cplusplus
}
#endif

#endif