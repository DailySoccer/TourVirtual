//
//  _MDPExternalChallengeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPExternalChallengeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPExternalChallengeModelAttributes {
	__unsafe_unretained NSString *idExternalChallenge;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *participationDate;
} MDPExternalChallengeModelAttributes;

@interface _MDPExternalChallengeModel : NSManagedObject

@property (nonatomic, strong) NSString* idExternalChallenge;

//- (BOOL)validateIdExternalChallenge:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* participationDate;

//- (BOOL)validateParticipationDate:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPExternalChallengeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdExternalChallenge;
- (void)setPrimitiveIdExternalChallenge:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveParticipationDate;
- (void)setPrimitiveParticipationDate:(NSDate*)value;

@end
