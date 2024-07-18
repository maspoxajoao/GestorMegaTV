import {
  Datagrid,
  List,
  NumberInput,
  SearchInput,
  TextField,
  DateField,
  BooleanField,
  FunctionField,
  DateTimeInput,
} from "react-admin";
import moment from "moment";

const filters = [
  <SearchInput source="q" />,
  <NumberInput source="id" label="Código" />,
  <DateTimeInput source="startDate" label="Data início" />,
  <DateTimeInput source="endDate" label="Data fim" />,
];

const isOnline = (date: Date) => {
  const then = moment(date);
  const now = moment();
  const differenceInMinutes = now.diff(then, "minutes");
  return differenceInMinutes < 5;
};

export const PlayerList = () => (
  <List filters={filters}>
    <Datagrid>
      <TextField source="id" label="Código" />
      <TextField source="descricao" label="Player" />
      <DateField showTime source="ultimaConexao" label="Última conexão" />
      <FunctionField
        label="Online"
        render={(r: any) => (
          <BooleanField
            source="online"
            record={{ online: isOnline(r.ultimaConexao) }}
          />
        )}
      />
    </Datagrid>
  </List>
);
