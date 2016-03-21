#ifndef SYMBOL_TABLE_H
#define SYMBOL_TABLE_H

typedef struct _symbol_table {

	struct _symbol_table_entry_t *entry;
	struct _symbol_table *next;

} symbol_table;

#endif // SYMBOL_TABLE_H
