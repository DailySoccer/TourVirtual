//
//  _MDPGoalModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGoalModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGoalModelAttributes {
	__unsafe_unretained NSString *assistPlayerName;
	__unsafe_unretained NSString *goalType;
	__unsafe_unretained NSString *idAssistPlayer;
	__unsafe_unretained NSString *idGoal;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *minute;
	__unsafe_unretained NSString *playerName;
} MDPGoalModelAttributes;

extern const struct MDPGoalModelRelationships {
	__unsafe_unretained NSString *footballTeamDataGoals;
	__unsafe_unretained NSString *period;
} MDPGoalModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPKeyValueObjectModel;

@interface _MDPGoalModel : NSManagedObject

@property (nonatomic, strong) NSString* assistPlayerName;

//- (BOOL)validateAssistPlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* goalType;

@property (atomic) uint16_t goalTypeValue;
- (uint16_t)goalTypeValue;
- (void)setGoalTypeValue:(uint16_t)value_;

//- (BOOL)validateGoalType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAssistPlayer;

//- (BOOL)validateIdAssistPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGoal;

//- (BOOL)validateIdGoal:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minute;

@property (atomic) int64_t minuteValue;
- (int64_t)minuteValue;
- (void)setMinuteValue:(int64_t)value_;

//- (BOOL)validateMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataGoals;

//- (BOOL)validateFootballTeamDataGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPGoalModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAssistPlayerName;
- (void)setPrimitiveAssistPlayerName:(NSString*)value;

- (NSNumber*)primitiveGoalType;
- (void)setPrimitiveGoalType:(NSNumber*)value;

- (uint16_t)primitiveGoalTypeValue;
- (void)setPrimitiveGoalTypeValue:(uint16_t)value_;

- (NSString*)primitiveIdAssistPlayer;
- (void)setPrimitiveIdAssistPlayer:(NSString*)value;

- (NSString*)primitiveIdGoal;
- (void)setPrimitiveIdGoal:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMinute;
- (void)setPrimitiveMinute:(NSNumber*)value;

- (int64_t)primitiveMinuteValue;
- (void)setPrimitiveMinuteValue:(int64_t)value_;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataGoals;
- (void)setPrimitiveFootballTeamDataGoals:(MDPFootballTeamDataModel*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

@end
