//
//  _MDPVenueModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPVenueModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPVenueModelAttributes {
	__unsafe_unretained NSString *capacity;
	__unsafe_unretained NSString *idStadium;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
} MDPVenueModelAttributes;

extern const struct MDPVenueModelRelationships {
	__unsafe_unretained NSString *teamStadium;
} MDPVenueModelRelationships;

@class MDPTeamModel;

@interface _MDPVenueModel : NSManagedObject

@property (nonatomic, strong) NSNumber* capacity;

@property (atomic) uint64_t capacityValue;
- (uint64_t)capacityValue;
- (void)setCapacityValue:(uint64_t)value_;

//- (BOOL)validateCapacity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idStadium;

//- (BOOL)validateIdStadium:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *teamStadium;

- (NSMutableSet*)teamStadiumSet;

@end

@interface _MDPVenueModel (TeamStadiumCoreDataGeneratedAccessors)
- (void)addTeamStadium:(NSSet*)value_;
- (void)removeTeamStadium:(NSSet*)value_;
- (void)addTeamStadiumObject:(MDPTeamModel*)value_;
- (void)removeTeamStadiumObject:(MDPTeamModel*)value_;
@end

@interface _MDPVenueModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCapacity;
- (void)setPrimitiveCapacity:(NSNumber*)value;

- (uint64_t)primitiveCapacityValue;
- (void)setPrimitiveCapacityValue:(uint64_t)value_;

- (NSString*)primitiveIdStadium;
- (void)setPrimitiveIdStadium:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSMutableSet*)primitiveTeamStadium;
- (void)setPrimitiveTeamStadium:(NSMutableSet*)value;

@end
