import * as React from "react";
import { Admin, EditGuesser, ListGuesser, Resource } from "react-admin";
import dataProvider from "./dataProvider";
import { PlayerList } from "./player/PlayerList";
import PlayerEdit from "./player/PlayerEdit";
import { MidiaList } from "./midia/MidiaList";
import { MidiaEdit } from "./midia/MidiaEdit";

const App = () => (
  <Admin dataProvider={dataProvider}>
    <Resource name="players" list={PlayerList} edit={PlayerEdit} />
    <Resource name="midias" list={MidiaList} edit={MidiaEdit} />
  </Admin>
);

export default App;
