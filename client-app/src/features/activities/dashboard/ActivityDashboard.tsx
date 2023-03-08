import React from "react";
import { Grid, List } from "semantic-ui-react";
import { Activity } from "../../../models/activity";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../forms/ActivityForm";
import ActivityList from "./ActivityList";
interface Props{
    activities:Activity[];
    selectedActivity: Activity | undefined;
    selectActivity:(id:string)=>void;
    cancelSelectActivity:()=>void;
    editMode: boolean;
    openForm:(id: string)=>void;
    closeForm:()=>void;
}

export default function ActivitiyDashboard({activities, selectedActivity, editMode, selectActivity, cancelSelectActivity, openForm, closeForm}: Props){
  return (
    <Grid>
      <Grid.Column width="10">
        <ActivityList activities={activities} selectActivity={selectActivity}/>
      </Grid.Column>
      <Grid.Column width='6'>
        {selectedActivity&&
        <ActivityDetails activity={selectedActivity} cancelSelectActivity={cancelSelectActivity} openForm={openForm}/>}
        {/* {editMode &&<ActivityForm closeForm={closeForm} activity={selectActivity}/>} */}
      </Grid.Column>
    </Grid>
  );
}