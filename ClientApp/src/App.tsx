import * as React from "react";
import { Admin, EditGuesser, ListGuesser, Resource } from "react-admin";
import dataProvider from "./dataProvider";
import { PlayerList } from "./player/PlayerList";
import PlayerEdit from "./player/PlayerEdit";
import { MidiaList } from "./midia/MidiaList";
import { MidiaEdit } from "./midia/MidiaEdit";
import { CampanhaList } from "./campanha/CampanhaList";

const App = () => (
  <Admin dataProvider={dataProvider}>
    <Resource name="players" list={PlayerList} edit={PlayerEdit} />
    <Resource name="midias" list={MidiaList} edit={MidiaEdit} />
    <Resource name="campanhas" list={CampanhaList} edit={EditGuesser} />
  </Admin>
);

export default App;
