import * as React from "react";
import { Admin, EditGuesser, ListGuesser, Resource } from "react-admin";
import dataProvider from "./dataProvider";
import { PlayerList } from "./player/PlayerList";

const App = () => (
    <Admin dataProvider={dataProvider}>
        <Resource name="players" list={PlayerList} edit={EditGuesser} />
    </Admin>
);

export default App;
