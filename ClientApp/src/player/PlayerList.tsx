import { Datagrid, List, NumberInput, SearchInput, TextField } from 'react-admin';

const filters = [<SearchInput source="q" />, <NumberInput source="id" />]

export const PlayerList = () => (
    <List filters={filters}>
        <Datagrid>
            <TextField source="id" />
            <TextField source="descricao" />
        </Datagrid>
    </List>
);