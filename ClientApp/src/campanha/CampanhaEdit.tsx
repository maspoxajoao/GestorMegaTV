import {
  ArrayInput,
  Edit,
  NumberInput,
  ReferenceInput,
  SimpleForm,
  SimpleFormIterator,
  TextInput,
  Datagrid,
  ReferenceManyField,
  TextField,
  SelectField,
  ImageField,
  InfiniteList,
  SelectInput,
  SearchInput,
  NumberField,
} from "react-admin";
import { tipos } from "../midia";
import { Grid, Box } from "@mui/material";

const MyBox = ({ children }: any) => {
  return (
    <Box
      sx={{
        mb: 2,
        pt: 6,
        display: "flex",
        flexDirection: "column",
        height: 600,
        overflow: "hidden",
        overflowY: "scroll",
        // justifyContent="flex-end" # DO NOT USE THIS WITH 'scroll'
      }}
    >
      {children}
    </Box>
  );
};

const filters = [
  <SearchInput source="q" alwaysOn />,
  <SelectInput choices={tipos} source="tipo" alwaysOn />,
];

export const CampanhaEdit = () => (
  <Edit>
    <SimpleForm>
      <Grid container columnSpacing={2}>
        <Grid item xs={12}>
          <TextInput source="descricao" label="Descrição" />
        </Grid>
        <Grid item xs={6}>
          <MyBox>
            <InfiniteList resource="midias" filters={filters}>
              <Datagrid>
                <ImageField source="imagemUrl" label="Imagem" />
                <TextField source="descricao" label="Mídia" />
                <NumberField source="duracao" label="Duração" />
                <SelectField choices={tipos} source="tipo" label="Tipo" />
              </Datagrid>
            </InfiniteList>
          </MyBox>
        </Grid>
        <Grid item xs={6}>
          <MyBox>
            <ReferenceManyField
              reference="campanhaMidias"
              target="campanhaId"
              label="Books"
            >
              <Datagrid>
                <ImageField source="midia.imagemUrl" label="Imagem" />
                <TextField source="midia.descricao" label="Mídia" />
                <NumberField source="duracao" label="Duração" />
                <SelectField choices={tipos} source="midia.tipo" label="Tipo" />
              </Datagrid>
            </ReferenceManyField>
          </MyBox>
        </Grid>
      </Grid>
    </SimpleForm>
  </Edit>
);
