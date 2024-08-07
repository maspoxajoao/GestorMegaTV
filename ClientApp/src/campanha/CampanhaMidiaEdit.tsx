import { DateInput, Edit, FunctionField, NumberInput, SimpleForm } from 'react-admin';
import { MidiaThumbnail } from '../midia/MidiaThumbnail';
import { ICampanhaMidia } from './ICampanhaMidia';

export const CampanhaMidiaEdit = () => (
    <Edit redirect="/campanhas/597">
        <SimpleForm>
        <FunctionField
                  render={(r: ICampanhaMidia) =><MidiaThumbnail midia={r.midia} />}
                />
            <NumberInput source="duracao" />
            <DateInput source="dataInicio"/>
            <DateInput source="dataFim"/>

        </SimpleForm>
    </Edit>
);