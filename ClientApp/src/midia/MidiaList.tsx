import {
  Datagrid,
  List,
  TextField,
  DateField,
  FunctionField,
  NumberInput,
  ImageField,
  SelectField,
  SearchInput,
  DateInput,
  SelectInput,
} from "react-admin";
import { tipos } from ".";
const filters = [
  <SearchInput source="q" alwaysOn />,
  <NumberInput source="id" label="Código" />,
  <DateInput source="startDate" label="Data início" />,
  <DateInput source="endDate" label="Data fim" />,
  <SelectInput source="tipo" choices={tipos} />,
];

export const MidiaList = () => (
  <List filters={filters}>
    <Datagrid>
      <TextField source="id" label="ID" />
      <FunctionField
        render={(r: any) =>
          r.tipo === "I" ? (
            <ImageField source="imagemUrl" label="Imagem" />
          ) : r.tipo === "V" ? (
            <video width="320" height="240" controls>
              <source src={r.imagemUrl} type="video/mp4" />
            </video>
          ) : (
            <ImageField source="arquivo" label="RSS" />
          )
        }
      />
      <TextField source="descricao" label="Descrição" />
      <TextField source="duracao" label="Duração" />
      <SelectField source="tipo" label="Tipo" choices={tipos} />
      <DateField source="dataEnvio" label="Data de envio" />
    </Datagrid>
  </List>
);
