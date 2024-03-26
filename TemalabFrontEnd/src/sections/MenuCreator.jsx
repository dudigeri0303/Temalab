import { DragDropContext, Draggable, Droppable } from 'react-beautiful-dnd';

export default function MenuCreator(){
    onDragEnd = result => {
        
    }

    return(
        <>
           <DragDropContext onDragEnd={this.onDragEnd}>
                <Droppable droppableId='0'>
                    {(provided) => {
                        <div
                        {...provided.droppableProps}
                        innerRef = {provided.innerRef}>
                        <p>Teszt próba</p>
                            <Draggable draggableId='0' index='0'>
                                {(provided) => {
                                    <div
                                    {...provided.draggableProps}
                                    {...provided.dragHandleProps}
                                    innerRef = {provided.innerRef}>
                                    <p>Első elem</p>
                                    </div>
                                }}
                            </Draggable>
                            <Draggable draggableId='1' index='0'>
                                {(provided) => {
                                    <div
                                    {...provided.draggableProps}
                                    {...provided.dragHandleProps}
                                    innerRef = {provided.innerRef}>
                                    <p>Második elem</p>
                                    </div>
                                }}
                            </Draggable>
                            <Draggable draggableId='2' index='0'>
                                {(provided) => {
                                    <div
                                    {...provided.draggableProps}
                                    {...provided.dragHandleProps}
                                    innerRef = {provided.innerRef}>
                                    <p>Harmadik elem</p>
                                    </div>
                                }}
                            </Draggable>
                        </div>
                    }}
                </Droppable>
           </DragDropContext>
        </>
    )
}