import {
  BooleanInput,
  DateInput,
  Edit,
  NumberInput,
  SimpleForm,
  TextInput,
  ImageField,
  SelectField,
  Labeled,
  NumberField,
  DateField,
} from "react-admin";
import { tipos } from ".";

export const MidiaEdit = () => (
  <Edit>
    <SimpleForm>
      <ImageField source="imagemUrl" />
      <Labeled>
        <SelectField choices={tipos} source="tipo" />
      </Labeled>
      <Labeled>
        <NumberField source="duracao" label="Duração" />
      </Labeled>
      <Labeled>
        <DateField source="dataEnvio" />
      </Labeled>
      <TextInput source="descricao" label="Descrição" />
    </SimpleForm>
  </Edit>
);
