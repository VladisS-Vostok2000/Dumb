## Deliver resourses from core to container without any transport delay

# Overview
This processor created for delivering resourses from
core to container (which is any building with resourse
capacity) using transport (any unit with load).

This processor created with idea of a fully universal,
so you might use it with fabrics, containers and
unit factories.

Using flying transport brings a lot of problems,
which is, for example, core or container depletion or oversupply,
returning resourse to core when container is full and uniform
distribution of resources.
So this processor tryies to resolve there issues.

This processor uses **single** transport for each built and supports two
strategy of core resourse usage.

## Supported languages
This processor created on english language with
a expanded variables identificators.

## Understanding problematics
First of all, there is two strategies about delivering:
core depletion or core resourses saving.

Core depletion implies taking all the resourse
from core without remainder, while resourse saving
strategy leave some count in core stopping delivery.

Anyway, when you want to deliver, you **must** check
core resourses count while transport isnt binded, because
if core resourse approximately `6`, while your transport,
for example, brings `20`, delivery becomes ineffective
(especially when core resourse count is zero).

For core saving resourses strategy, you may determiny
one bound which designating deliver or not deliver.
But what is your transport is already took the
resourse, but core resourse count became lower?
It turns out that transport did needless motion.
To prevent this, you must determiny second bound.
From first below bound transport must return a resourse
to the core; in the between it can return and deliver at
the same time; and the above must only deliver.

The gap between bound switches between deliver
or returning a resourse to core automatically,
dependment of core resourse derevative.
To clear that thing, i suggest looking at the graf below:

As you can see, the 



### Core depletion





## Configuration documentation
To use this processor, u must set up
a several variables.
To do this, u must understand what each of them does.

To find processor configuration variables, you must
open processor in ui editor or text redactor, and
find `set` instructions in the begginning;
but some variables set after processor body which
starts with `print flush` instruction.

### General variables
For correct processor working, following variables must be declared: `transportType`, `res`.

#### Variable `transportType`
To set transport, which must delivering, please use
`transportType` variable.
For example,

`set transportType @flare`

#### Variable `res`
To set resourses, which transport must deliver,
please use `res1`, `res2`, `res3`, `res4` instructions.

For example,
```
set res1 @silicon
set res2 null
set res3 @lead
set res4 null
```
You can set only 4 types of resourses, which will deliver. `null`-set resourses will be ignored. You do no need to set other dependment variables to set them null, if resourse is ignored.

### Saving resourse strategy variables
For saving resourses strategy, following variables must be declared:
`resCoreLowBound`, `resCoreAlmostLowBound`, `resCoreEnoughBound`.

#### Variable `resCoreLowBound`
This bound determinyses should transport return resourse to core and can it take one.
If its below, it *should* return it to core and *can't* take it. If its above, it *might* return to core and *can't* take it.

The higher you set this variable, the higher resourses will saved in the core.

For example:
```
set res1CoreLowBound 500
set res2CoreLowBound null
set res3CoreLowBound 100
set res4CoreLowBound null
```

#### Variable `resCoreAlmostLowBound`
This bound determinyses, might transport return resourse to core and 
If its below, it *can't* take resourse and *might* return it to core. If its above, it *might* take resourse and *mustn't* return it to core.

The higher you set this variable, the higher processor protected from extra motions, at the same time slowing down speed of delivery.

For example, you set `resCoreLowBound` for `100`. Transport capacity is `10`. You have 3 processors. You set up `resCoreAlmostLowBound` for `120`. When 3 your transport at the same time will took your `res`, when core stored is `120`, it will become `90`, that will order your transport drop resourse into core again. This is extra motion.
To prevent this, please use recommended setup.

This variable must be `>`, than `resCoreLowBound` and recommended be `resCoreLowBound + transportCount * transportCapacity * N`
where `N` is your custom constant `>1`.

For example:
```
set res1CoreAlmostLowBound 540
set res2CoreAlmostLowBound null
set res3CoreAlmostLowBound 140
set res4CoreAlmostLowBound null
```
#### Variable `resCoreEnoughBound`
This bound determinyses might transport take resourse from core.
If below, it *might*. If above, it *must*.

The higher you set this variable, the longer transport will use core resourses while it brings down, at the same time slowing starting delivery.

This variable must be `>`, than `resCoreAlmostLowBound`.

For example:
```
set res1CoreEnoughBound 1000
set res2CoreEnoughBound null
set res3CoreEnoughBound 250
set res4CoreEnoughBound null
```

### Core depletion strategy variables
For depletion core strategy following variables must be declared: `resDepletionCoreLowBound`, `resDepletionCoreEnoughBound`.

#### Variable `resDepletionCoreLowBound`
This bound determinyses if transport can take resourses from core. 
If below, transport *cant* take the resourse. If above, transport *might* take the resouse.

The higher you set this variable, less exceed motions transport will do, at the same time slowing start of delivering.

For example:
```
set res1DepletionCoreLowBound 100
set res2DepletionCoreLowBound null
set res3DepletionCoreLowBound 100
set res4DepletionCoreLowBound null
```

#### Variable `resDepletionCoreEnoughBound`
This bound determinyses if transport can take resourses from core.
If below, transport *might* take the resourse. If above, transport *must* take the resouse.

The higher you set this variable, the longer will transport rest and safer of transport exceed motions, at the same time slowing down speed of deliver.

For example, you set `resDepletionCoreLowBound` for `100`. Transport capacity is `10`. You have 3 processors. You set up `res1DepletionCoreEnoughBound` for `110`. When 2 of your transport at the same time will took your `res`, when core stored is `111`, it will become `91`, that will order your third transport, approaching to core, to stop. This is extra motion.
To prevent this, please use recommended setup.

This variable must be `>`, than `resDepletionCoreLowBound` and recommended be `resDepletionCoreLowBound + transportCount * transportCapacity * N` where `N` is your custom constant `>1`.

For example:
```
set res1DepletionCoreEnoughBound 200
set res2DepletionCoreEnoughBound null
set res3DepletionCoreEnoughBound 200
set res4DepletionCoreEnoughBound null
```
### Container variables
For correct processor working, following variables must be declared: `resContainerLowBound`, `resContainerMinBound`, `resContainerEnoughBound`.

#### Variable `resContainerLowBound`
This bound determinyses which resourse, that container needs, must be delivered first to factory start work.

For example, you set `res1ContainerLowBound` for `40`, `res2ContainerLowBound` same for `40`, while container contains `50` and `25` accordingly. The first resourse will be delivered is `res2`.

The higher you set this variable, the later factory will start work.

The recommended setup is minimum of resourse, that needs to factory start work.

For example:
```
set res1ContainerLowBound 30
set res2ContainerLowBound null
set res3ContainerLowBound 15
set res4ContainerLowBound null
```

#### Variable `resContainerMinBound`
This bound determinyses which resourse, that container needs, must be delivered first while factory working to provide uniform resourse delivering, preventing stop factory working without one of resourse type.

For example, you set `res1ContainerMinBound` for `40`, `res2ContainerMinBound` same for `40`, while container contains `50` and `25` accordingly. The first resourse will be delivered is `res2`. 

This variable must be `>`, than `resContainerLowBound`.

For example:
```
set res1ContainerMinBound 60
set res2ContainerMinBound null
set res3ContainerMinBound 30
set res4ContainerMinBound null
```

#### Variable `resContainerEnoughBound`
This bound determinyses can unit deliver resourse to container.
If above, it *can't*. If below, it *can*.

The higher you set this variable, the longer will be transport rest between delivery, at the same time longer will be actually deliver.

To prevent unit exceed motions, you may set up this variable about hight container resourse capacity bound carefully.

For example, you set up `res1ContainerEnoughBound` for `300` while container capacity is `300`. You built 3 processors. When container resourse stored is `290`, all the transports will take the aforementioned resourse, that will cause returning resourse to core two of three transports, what is exceed motion.
To prevent this, please use recommended setup.

This variable must be `>`, than `resContainerMinBound` and recommended be `resContainerCapacity - transportCount * transportCapacity`.

For example:
```
set res1ContainerEnoughBound 60
set res2ContainerEnoughBound null
set res3ContainerEnoughBound 30
set res4ContainerEnoughBound null
```

