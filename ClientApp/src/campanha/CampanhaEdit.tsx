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
  EditButton,
  DateField,
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

const MoveButtons = ({ label, direcao }: { label: string; direcao: string }) => {
  const [create] = useCreate();
  const refresh = useRefresh();
  const { selectedIds } = useListContext();

  const mover = (direcao: string) => {
    create(
      `campanhamidias/mover/${direcao}`,
      { data: selectedIds },
      {
        onSuccess: () => {
          refresh();
        },
      }
    );
  };

  return <Button label={label} onClick={() => mover(direcao)} />;
};

const CampanhaMidiasBulkActionButtons = () => {
  return (
    <>
      <MoveButtons label="Para cima" direcao="cima" />
      <MoveButtons label="Para baixo" direcao="baixo" />
      <BulkDeleteButton />
    </>
  );
};

export const CampanhaEdit = () => (
  <Edit>
    <SimpleForm>
      <Grid container columnSpacing={2}>
        <Grid item xs={12}>
          <TextInput source="descricao" label="Descrição" />
        </Grid>
        <Grid item xs={4}>
          <MyBox>
            <InfiniteList resource="midias" filters={filters}>
              <Datagrid bulkActionButtons={<MidiasBulkActionButtons />}>
                <FunctionField
                  render={(r: IMidia) => <MidiaThumbnail midia={r} />}
                />
                <TextField source="descricao" label="Mídia" />
                <SelectField choices={tipos} source="tipo" label="Tipo" />
              </Datagrid>
            </InfiniteList>
          </MyBox>
        </Grid>
        <Grid item xs={8}>
          <MyBox>
            <ReferenceManyField
              reference="campanhaMidias"
              target="campanhaId"
              label="Mídias da Campanha"
              sort={{ field: "posicao", order: "ASC" }}
            >
              <Datagrid
                sx={{ pt: "48px" }}
                bulkActionButtons={<CampanhaMidiasBulkActionButtons />}
              >
                <FunctionField
                  render={(r: ICampanhaMidia) => (
                    <MidiaThumbnail midia={r.midia} />
                  )}
                />
                <TextField source="midia.descricao" label="Mídia" />
                <TextField source="posicao" />
                <NumberField source="duracao" label="Duração" />
                <SelectField choices={tipos} source="midia.tipo" label="Tipo" />
                <DateField source="dataInicio" label="Início"/>
                <DateField source="dataFim" label="Fim"/>
                <EditButton />
              </Datagrid>
            </ReferenceManyField>
          </MyBox>
        </Grid>
      </Grid>
    </SimpleForm>
  </Edit>
);
