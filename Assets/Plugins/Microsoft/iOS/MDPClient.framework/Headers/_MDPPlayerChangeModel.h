//
//  _MDPPlayerChangeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlayerChangeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlayerChangeModelAttributes {
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *height;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *jerseyNum;
	__unsafe_unretained NSString *joinDate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *leaveDate;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *nnewTeam;
	__unsafe_unretained NSString *realPosition;
	__unsafe_unretained NSString *realPositionSide;
	__unsafe_unretained NSString *weight;
} MDPPlayerChangeModelAttributes;

extern const struct MDPPlayerChangeModelRelationships {
	__unsafe_unretained NSString *teamPlayerChanges;
} MDPPlayerChangeModelRelationships;

@class MDPTeamModel;

@interface _MDPPlayerChangeModel : NSManagedObject

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* height;

//- (BOOL)validateHeight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* jerseyNum;

@property (atomic) uint64_t jerseyNumValue;
- (uint64_t)jerseyNumValue;
- (void)setJerseyNumValue:(uint64_t)value_;

//- (BOOL)validateJerseyNum:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* joinDate;

//- (BOOL)validateJoinDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* leaveDate;

//- (BOOL)validateLeaveDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* nnewTeam;

//- (BOOL)validateNnewTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* realPosition;

//- (BOOL)validateRealPosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* realPositionSide;

//- (BOOL)validateRealPositionSide:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* weight;

//- (BOOL)validateWeight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTeamModel *teamPlayerChanges;

//- (BOOL)validateTeamPlayerChanges:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlayerChangeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSDecimalNumber*)primitiveHeight;
- (void)setPrimitiveHeight:(NSDecimalNumber*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSNumber*)primitiveJerseyNum;
- (void)setPrimitiveJerseyNum:(NSNumber*)value;

- (uint64_t)primitiveJerseyNumValue;
- (void)setPrimitiveJerseyNumValue:(uint64_t)value_;

- (NSDate*)primitiveJoinDate;
- (void)setPrimitiveJoinDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveLeaveDate;
- (void)setPrimitiveLeaveDate:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveNnewTeam;
- (void)setPrimitiveNnewTeam:(NSString*)value;

- (NSString*)primitiveRealPosition;
- (void)setPrimitiveRealPosition:(NSString*)value;

- (NSString*)primitiveRealPositionSide;
- (void)setPrimitiveRealPositionSide:(NSString*)value;

- (NSDecimalNumber*)primitiveWeight;
- (void)setPrimitiveWeight:(NSDecimalNumber*)value;

- (MDPTeamModel*)primitiveTeamPlayerChanges;
- (void)setPrimitiveTeamPlayerChanges:(MDPTeamModel*)value;

@end
