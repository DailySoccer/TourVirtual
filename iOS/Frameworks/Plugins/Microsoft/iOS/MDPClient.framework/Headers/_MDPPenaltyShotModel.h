//
//  _MDPPenaltyShotModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPenaltyShotModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPenaltyShotModelAttributes {
	__unsafe_unretained NSString *eventNumber;
	__unsafe_unretained NSString *idEvent;
	__unsafe_unretained NSString *idPenaltyShot;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *outcome;
	__unsafe_unretained NSString *playerName;
} MDPPenaltyShotModelAttributes;

extern const struct MDPPenaltyShotModelRelationships {
	__unsafe_unretained NSString *shootOutPenaltyShots;
} MDPPenaltyShotModelRelationships;

@class MDPShootOutModel;

@interface _MDPPenaltyShotModel : NSManagedObject

@property (nonatomic, strong) NSString* eventNumber;

//- (BOOL)validateEventNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idEvent;

//- (BOOL)validateIdEvent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPenaltyShot;

//- (BOOL)validateIdPenaltyShot:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* outcome;

@property (atomic) uint16_t outcomeValue;
- (uint16_t)outcomeValue;
- (void)setOutcomeValue:(uint16_t)value_;

//- (BOOL)validateOutcome:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPShootOutModel *shootOutPenaltyShots;

//- (BOOL)validateShootOutPenaltyShots:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPenaltyShotModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveEventNumber;
- (void)setPrimitiveEventNumber:(NSString*)value;

- (NSString*)primitiveIdEvent;
- (void)setPrimitiveIdEvent:(NSString*)value;

- (NSString*)primitiveIdPenaltyShot;
- (void)setPrimitiveIdPenaltyShot:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOutcome;
- (void)setPrimitiveOutcome:(NSNumber*)value;

- (uint16_t)primitiveOutcomeValue;
- (void)setPrimitiveOutcomeValue:(uint16_t)value_;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (MDPShootOutModel*)primitiveShootOutPenaltyShots;
- (void)setPrimitiveShootOutPenaltyShots:(MDPShootOutModel*)value;

@end
