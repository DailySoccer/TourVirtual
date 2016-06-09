//
//  _MDPHonourModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPHonourModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPHonourModelAttributes {
	__unsafe_unretained NSString *idHonour;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *season;
} MDPHonourModelAttributes;

extern const struct MDPHonourModelRelationships {
	__unsafe_unretained NSString *playerIndividualHonours;
	__unsafe_unretained NSString *teamHonours;
} MDPHonourModelRelationships;

@class MDPPlayerModel;
@class MDPTeamModel;

@interface _MDPHonourModel : NSManagedObject

@property (nonatomic, strong) NSString* idHonour;

//- (BOOL)validateIdHonour:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* season;

//- (BOOL)validateSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *playerIndividualHonours;

- (NSMutableSet*)playerIndividualHonoursSet;

@property (nonatomic, strong) NSSet *teamHonours;

- (NSMutableSet*)teamHonoursSet;

@end

@interface _MDPHonourModel (PlayerIndividualHonoursCoreDataGeneratedAccessors)
- (void)addPlayerIndividualHonours:(NSSet*)value_;
- (void)removePlayerIndividualHonours:(NSSet*)value_;
- (void)addPlayerIndividualHonoursObject:(MDPPlayerModel*)value_;
- (void)removePlayerIndividualHonoursObject:(MDPPlayerModel*)value_;
@end

@interface _MDPHonourModel (TeamHonoursCoreDataGeneratedAccessors)
- (void)addTeamHonours:(NSSet*)value_;
- (void)removeTeamHonours:(NSSet*)value_;
- (void)addTeamHonoursObject:(MDPTeamModel*)value_;
- (void)removeTeamHonoursObject:(MDPTeamModel*)value_;
@end

@interface _MDPHonourModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdHonour;
- (void)setPrimitiveIdHonour:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveSeason;
- (void)setPrimitiveSeason:(NSString*)value;

- (NSMutableSet*)primitivePlayerIndividualHonours;
- (void)setPrimitivePlayerIndividualHonours:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTeamHonours;
- (void)setPrimitiveTeamHonours:(NSMutableSet*)value;

@end
