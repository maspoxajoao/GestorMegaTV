import * as React from "react";
import { Admin, EditGuesser, ListGuesser, Resource } from "react-admin";
import dataProvider from "./dataProvider";
import { PlayerList } from "./player/PlayerList";
import PlayerEdit from "./player/PlayerEdit";

const App = () => (
  <Admin dataProvider={dataProvider}>
    <Resource name="players" list={PlayerList} edit={PlayerEdit} />
  </Admin>
);

export default App;
