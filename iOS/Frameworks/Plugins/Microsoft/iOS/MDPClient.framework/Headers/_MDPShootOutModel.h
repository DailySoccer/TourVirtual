//
//  _MDPShootOutModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPShootOutModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPShootOutModelAttributes {
	__unsafe_unretained NSString *firstPenalty;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPShootOutModelAttributes;

extern const struct MDPShootOutModelRelationships {
	__unsafe_unretained NSString *footballTeamDataShootOut;
	__unsafe_unretained NSString *penaltyShots;
} MDPShootOutModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPPenaltyShotModel;

@interface _MDPShootOutModel : NSManagedObject

@property (nonatomic, strong) NSNumber* firstPenalty;

@property (atomic) BOOL firstPenaltyValue;
- (BOOL)firstPenaltyValue;
- (void)setFirstPenaltyValue:(BOOL)value_;

//- (BOOL)validateFirstPenalty:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataShootOut;

//- (BOOL)validateFootballTeamDataShootOut:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *penaltyShots;

- (NSMutableSet*)penaltyShotsSet;

@end

@interface _MDPShootOutModel (PenaltyShotsCoreDataGeneratedAccessors)
- (void)addPenaltyShots:(NSSet*)value_;
- (void)removePenaltyShots:(NSSet*)value_;
- (void)addPenaltyShotsObject:(MDPPenaltyShotModel*)value_;
- (void)removePenaltyShotsObject:(MDPPenaltyShotModel*)value_;
@end

@interface _MDPShootOutModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveFirstPenalty;
- (void)setPrimitiveFirstPenalty:(NSNumber*)value;

- (BOOL)primitiveFirstPenaltyValue;
- (void)setPrimitiveFirstPenaltyValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataShootOut;
- (void)setPrimitiveFootballTeamDataShootOut:(MDPFootballTeamDataModel*)value;

- (NSMutableSet*)primitivePenaltyShots;
- (void)setPrimitivePenaltyShots:(NSMutableSet*)value;

@end
