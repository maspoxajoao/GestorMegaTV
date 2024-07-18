import {
  BooleanInput,
  DateInput,
  Edit,
  SimpleForm,
  TextInput,
  SelectInput,
  required,
  DateField,
  Labeled,
} from "react-admin";

const PlayerEdit = () => (
  <Edit>
    <SimpleForm>
      <TextInput source="descricao" label="Player" />
      <SelectInput
        source="orientacao"
        label="Orientação"
        validate={required()}
        choices={[
          { id: "0", name: "Horizontal" },
          { id: "1", name: "Vertical" },
        ]}
      />
      <BooleanInput source="desativarAudio" />
      <BooleanInput source="exibirRelogio" label="Exibir relógio" />
      <BooleanInput source="caixaLivre" />
      <BooleanInput source="senhas" />
      <Labeled>
        <DateField source="ultimaConexao" label="Última conexão" />
      </Labeled>
    </SimpleForm>
  </Edit>
);

export default PlayerEdit;
