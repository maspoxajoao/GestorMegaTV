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
  useUpdate,
} from "react-admin";
import { tipos } from "../midia";
import { Grid, Box } from "@mui/material";
import { MidiaThumbnail } from "../midia/MidiaThumbnail";
import { ICampanhaMidia } from "./ICampanhaMidia";
import { IMidia } from "../midia/IMidia";

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

const MidiasBulkActionButtons = () => {
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
        }}
      />
    </Box>
  );
};

const CampanhaMidiasBulkActionButtons = () => {
  return (
    <>
      <BulkDeleteButton />
    </>
  );
};

const MoveButtons = ({ record }: any) => {
  const [update] = useUpdate();
  const refresh = useRefresh();

  const moveCima = () => {
    update(
      `campanhamidias/mover/cima`,
      { id: record.id, data: {} },
      {
        onSuccess: () => {
          refresh();
        },
      }
    );
  };

  const moveBaixo = () => {
    update(
      `campanhamidias/mover/baixo`,
      { id: record.id, data: {} },
      {
        onSuccess: () => {
          refresh();
        },
      }
    );
  };

  return (
    <Box display="flex" flexDirection="column">
      <Button label="Para Cima" onClick={moveCima} />
      <Button label="Para Baixo" onClick={moveBaixo} />
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
              <Datagrid bulkActionButtons={<MidiasBulkActionButtons />}>
                <FunctionField
                  render={(r: IMidia) => <MidiaThumbnail midia={r} />}
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
                  render={(r: ICampanhaMidia) => (
                    <MidiaThumbnail midia={r.midia} />
                  )}
                />
                <TextField source="midia.descricao" label="Mídia" />
                <TextField source="posicao" />
                <NumberField source="duracao" label="Duração" />
                <SelectField choices={tipos} source="midia.tipo" label="Tipo" />
                <FunctionField
                  render={(record: any) => <MoveButtons record={record} />}
                />
              </Datagrid>
            </ReferenceManyField>
          </MyBox>
        </Grid>
      </Grid>
    </SimpleForm>
  </Edit>
);
