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
  BulkUpdateButton,
  BulkDeleteButton,
  BulkExportButton,
  Button,
  FunctionField,
  useListContext,
  useCreate,
  useRecordContext,
  useRefresh,
  useNotify,
} from "react-admin";
import { tipos } from "../midia";
import { Grid, Box } from "@mui/material";

const MyBox = ({ children }: any) => {
  return (
    <Box
      sx={{
        mb: 2,
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

const PostBulkActionButtons = () => {
  const refresh = useRefresh();
  const record = useRecordContext();
  const { selectedIds } = useListContext();
  const [create] = useCreate();
  const notify = useNotify();
  console.log(record);
  return (
    <Box>
      <Button
        label="Adicionar"
        onClick={() => {
          create(
            `campanhamidias/add/${record!.id}`,
            { data: selectedIds },
            {
              onSuccess: () => {
                refresh();
                notify("Mídias inseridas com sucesso.");
              },
            }
          );
          // console.log(selectedIds);
          // fetch("api/campanhamidias/add", {
          //   method: "POST",
          //   headers: {
          //     "Content-type": "application/json",
          //   },
          //   body: JSON.stringify(selectedIds),
          // });
        }}
      />
    </Box>
  );
};

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
              <Datagrid bulkActionButtons={<PostBulkActionButtons />}>
                <FunctionField
                  render={(r: any) =>
                    r.tipo === "I" ? (
                      <ImageField source="imagemUrl" label="Imagem" />
                    ) : r.tipo === "V" ? (
                      <video width="256" height="192" controls>
                        <source src={r.imagemUrl} type="video/mp4" />
                      </video>
                    ) : (
                      <ImageField source="arquivo" label="RSS" />
                    )
                  }
                />
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
              sort={{ field: "posicao", order: "ASC" }}
            >
              <Datagrid sx={{ pt: "48px" }}>
                <FunctionField
                  render={(r: any) =>
                    r.midia.tipo === "I" ? (
                      <ImageField source="midia.imagemUrl" label="Imagem" />
                    ) : r.midia.tipo === "V" ? (
                      <video width="256" height="192" controls>
                        <source src={r.midia.imagemUrl} type="video/mp4" />
                      </video>
                    ) : (
                      <ImageField source="midia.arquivo" label="RSS" />
                    )
                  }
                />
                <TextField source="midia.descricao" label="Mídia" />
                <TextField source="posicao" />
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
