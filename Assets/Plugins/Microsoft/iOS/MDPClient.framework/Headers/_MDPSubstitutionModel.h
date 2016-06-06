//
//  _MDPSubstitutionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubstitutionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubstitutionModelAttributes {
	__unsafe_unretained NSString *eventNumber;
	__unsafe_unretained NSString *idEvent;
	__unsafe_unretained NSString *idPlayerOff;
	__unsafe_unretained NSString *idPlayerOn;
	__unsafe_unretained NSString *idSubstituion;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *minute;
	__unsafe_unretained NSString *playerOffName;
	__unsafe_unretained NSString *playerOnName;
	__unsafe_unretained NSString *substitutePosition;
	__unsafe_unretained NSString *substitutionReason;
} MDPSubstitutionModelAttributes;

extern const struct MDPSubstitutionModelRelationships {
	__unsafe_unretained NSString *footBallTeamDataSubstitutions;
	__unsafe_unretained NSString *period;
} MDPSubstitutionModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPKeyValueObjectModel;

@interface _MDPSubstitutionModel : NSManagedObject

@property (nonatomic, strong) NSString* eventNumber;

//- (BOOL)validateEventNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idEvent;

//- (BOOL)validateIdEvent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayerOff;

//- (BOOL)validateIdPlayerOff:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayerOn;

//- (BOOL)validateIdPlayerOn:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubstituion;

//- (BOOL)validateIdSubstituion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minute;

@property (atomic) int64_t minuteValue;
- (int64_t)minuteValue;
- (void)setMinuteValue:(int64_t)value_;

//- (BOOL)validateMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerOffName;

//- (BOOL)validatePlayerOffName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerOnName;

//- (BOOL)validatePlayerOnName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* substitutePosition;

//- (BOOL)validateSubstitutePosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* substitutionReason;

@property (atomic) uint16_t substitutionReasonValue;
- (uint16_t)substitutionReasonValue;
- (void)setSubstitutionReasonValue:(uint16_t)value_;

//- (BOOL)validateSubstitutionReason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footBallTeamDataSubstitutions;

//- (BOOL)validateFootBallTeamDataSubstitutions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPSubstitutionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveEventNumber;
- (void)setPrimitiveEventNumber:(NSString*)value;

- (NSString*)primitiveIdEvent;
- (void)setPrimitiveIdEvent:(NSString*)value;

- (NSString*)primitiveIdPlayerOff;
- (void)setPrimitiveIdPlayerOff:(NSString*)value;

- (NSString*)primitiveIdPlayerOn;
- (void)setPrimitiveIdPlayerOn:(NSString*)value;

- (NSString*)primitiveIdSubstituion;
- (void)setPrimitiveIdSubstituion:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMinute;
- (void)setPrimitiveMinute:(NSNumber*)value;

- (int64_t)primitiveMinuteValue;
- (void)setPrimitiveMinuteValue:(int64_t)value_;

- (NSString*)primitivePlayerOffName;
- (void)setPrimitivePlayerOffName:(NSString*)value;

- (NSString*)primitivePlayerOnName;
- (void)setPrimitivePlayerOnName:(NSString*)value;

- (NSString*)primitiveSubstitutePosition;
- (void)setPrimitiveSubstitutePosition:(NSString*)value;

- (NSNumber*)primitiveSubstitutionReason;
- (void)setPrimitiveSubstitutionReason:(NSNumber*)value;

- (uint16_t)primitiveSubstitutionReasonValue;
- (void)setPrimitiveSubstitutionReasonValue:(uint16_t)value_;

- (MDPFootballTeamDataModel*)primitiveFootBallTeamDataSubstitutions;
- (void)setPrimitiveFootBallTeamDataSubstitutions:(MDPFootballTeamDataModel*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

@end
