import { ImageField, ImageInput } from 'react-admin';

export const MidiaList = () => (
    <ImageInput source="avatar" label="Player Avatar" accept="image/*">
        <ImageField source="endereco" title="title" />
    </ImageInput>
);